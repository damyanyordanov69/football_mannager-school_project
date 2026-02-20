USE football_mannager;

-- Добавяне на лига
INSERT INTO Leagues (name) VALUES ('Premier League');

-- Добавяне на отбори
INSERT INTO Teams (name, city, league_id) VALUES 
('Lions FC', 'Sofia', 1),
('Eagles United', 'Plovdiv', 1),
('Sharks FC', 'Varna', 1),
('Dragons', 'Ruse', 1);

-- Добавяне на играчи
INSERT INTO Players (first_name, last_name, age, team_id) VALUES 
('Ivan', 'Ivanov', 25, 1), ('Georgi', 'Petrov', 22, 1),
('Stefan', 'Stoianov', 28, 2), ('Dimitar', 'Berbatov', 35, 2),
('Nikolay', 'Kolev', 21, 3), ('Hristo', 'Stoichkov', 40, 3),
('Petar', 'Zanev', 24, 4), ('Martin', 'Petrov', 30, 4);

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