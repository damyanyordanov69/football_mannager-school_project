using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace FootballProject
{
    public class TransfersRepository
    {
        // 1. Взимане на историята (с филтър по отбор) + JOIN за имената
        public List<Transfer> GetTransfers(int? teamIdFilter = null)
        {
            var transfers = new List<Transfer>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT tr.transfer_id, tr.player_id, CONCAT(p.first_name, ' ', p.last_name) AS player_name,
                           tr.from_team_id, t_from.name AS from_team_name,
                           tr.to_team_id, t_to.name AS to_team_name,
                           tr.transfer_fee, tr.transfer_date
                    FROM Transfers tr
                    JOIN Players p ON tr.player_id = p.player_id
                    LEFT JOIN Teams t_from ON tr.from_team_id = t_from.team_id
                    JOIN Teams t_to ON tr.to_team_id = t_to.team_id
                    WHERE 1=1 ";

                if (teamIdFilter.HasValue && teamIdFilter.Value > 0)
                {
                    sql += " AND (tr.from_team_id = @teamId OR tr.to_team_id = @teamId) ";
                }

                sql += " ORDER BY tr.transfer_date ASC";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (teamIdFilter.HasValue && teamIdFilter.Value > 0)
                        cmd.Parameters.AddWithValue("@teamId", teamIdFilter.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transfers.Add(new Transfer
                            {
                                TransferId = Convert.ToInt32(reader["transfer_id"]),
                                PlayerId = Convert.ToInt32(reader["player_id"]),
                                PlayerName = reader["player_name"].ToString(),
                                FromTeamId = reader["from_team_id"] != DBNull.Value ? Convert.ToInt32(reader["from_team_id"]) : (int?)null,
                                FromTeamName = reader["from_team_name"].ToString(),
                                ToTeamId = Convert.ToInt32(reader["to_team_id"]),
                                ToTeamName = reader["to_team_name"].ToString(),
                                TransferFee = Convert.ToDecimal(reader["transfer_fee"]),
                                TransferDate = Convert.ToDateTime(reader["transfer_date"])
                            });
                        }
                    }
                }
            }
            return transfers;
        }

        // 2. ДОБАВЯНЕ НА ТРАНСФЕР (С ТРАНЗАКЦИЯ - Изискване за Отличен!)
        public void PerformTransfer(int playerId, int fromTeamId, int toTeamId, decimal fee, DateTime date)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                // Започваме транзакция!
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // СТЪПКА А: Записваме в таблица Transfers
                        string sqlInsert = "INSERT INTO Transfers (player_id, from_team_id, to_team_id, transfer_fee, transfer_date) VALUES (@pId, @fromId, @toId, @fee, @date)";
                        using (var cmdInsert = new MySqlCommand(sqlInsert, conn, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@pId", playerId);
                            cmdInsert.Parameters.AddWithValue("@fromId", fromTeamId);
                            cmdInsert.Parameters.AddWithValue("@toId", toTeamId);
                            cmdInsert.Parameters.AddWithValue("@fee", fee);
                            cmdInsert.Parameters.AddWithValue("@date", date);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // СТЪПКА Б: Променяме отбора на играча в таблица Players
                        string sqlUpdate = "UPDATE Players SET team_id = @toId WHERE player_id = @pId";
                        using (var cmdUpdate = new MySqlCommand(sqlUpdate, conn, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@toId", toTeamId);
                            cmdUpdate.Parameters.AddWithValue("@pId", playerId);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        // Ако и двете минат успешно - запазваме!
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Ако нещо гръмне, отменяме всичко! (Rollback)
                        transaction.Rollback();
                        throw new Exception("Трансферът се провали: " + ex.Message);
                    }
                }
            }
        }
    }
}