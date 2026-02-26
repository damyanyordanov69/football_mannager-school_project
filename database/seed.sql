USE football_mannager;

-- Добавяне на лига
INSERT INTO Leagues (name) VALUES ('Premier League');

-- Добавяне на отбори
INSERT INTO Teams (name, city, league_id) VALUES 
('Lions FC', 'Sofia', 1),
('Eagles United', 'Plovdiv', 1),
('Sharks FC', 'Varna', 1),
('Dragons', 'Ruse', 1);

-- Добавяне на играчи (ОБНОВЕНИ с дата на раждане и позиция спрямо новата таблица)
INSERT INTO Players (first_name, last_name, birth_date, position, team_id) VALUES 
('Ivan', 'Ivanov', '1998-05-14', 'FW', 1), 
('Georgi', 'Petrov', '2001-08-22', 'MF', 1),
('Stefan', 'Stoianov', '1995-10-10', 'DF', 2), 
('Dimitar', 'Berbatov', '1988-01-30', 'FW', 2),
('Nikolay', 'Kolev', '2002-07-07', 'MF', 3), 
('Hristo', 'Stoichkov', '1983-02-08', 'FW', 3),
('Petar', 'Zanev', '1999-12-01', 'DF', 4), 
('Martin', 'Petrov', '1993-01-15', 'MF', 4),
-- Добавени още 2 играчи, за да станат общо 10 (според изискванията на учителя)
('Dimitar', 'Iliev', '1990-05-05', 'GK', 1),
('Nikolay', 'Mihaylov', '1988-08-12', 'GK', 2);

-- Добавяне на мачове
INSERT INTO Matches (home_team_id, away_team_id, home_score, away_score, match_date) 
VALUES (1, 2, 2, 1, '2023-10-01');

INSERT INTO Matches (home_team_id, away_team_id, home_score, away_score, match_date) 
VALUES (3, 4, 0, 0, '2023-10-05');

-- НОВИ ЗАПИСИ: Трансфери
-- Ivan Ivanov се мести от Lions FC (1) в Eagles United (2)
INSERT INTO Transfers (player_id, from_team_id, to_team_id, transfer_fee, transfer_date)
VALUES (1, 1, 2, 500000.00, '2023-11-01');

-- Nikolay Kolev се мести от Sharks FC (3) в Lions FC (1)
INSERT INTO Transfers (player_id, from_team_id, to_team_id, transfer_fee, transfer_date)
VALUES (5, 3, 1, 120000.00, '2023-11-15');
