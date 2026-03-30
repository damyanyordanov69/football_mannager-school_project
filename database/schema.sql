CREATE DATABASE IF NOT EXISTS football_manager;
USE football_manager;

-- Изтриваме таблиците в обратен ред, за да не нарушим Foreign Key връзките
DROP TABLE IF EXISTS Matches;
DROP TABLE IF EXISTS league_teams;
DROP TABLE IF EXISTS Transfers;
DROP TABLE IF EXISTS Players;
DROP TABLE IF EXISTS Leagues;
DROP TABLE IF EXISTS Teams;

-- 1. Таблица Отбори
CREATE TABLE Teams (
    team_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    city VARCHAR(100) NOT NULL
);

-- 2. Таблица Играчи
CREATE TABLE Players (
    player_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    birth_date DATE NOT NULL,
    position VARCHAR(5) NOT NULL,
    team_id INT,
    FOREIGN KEY (team_id) REFERENCES Teams(team_id) ON DELETE SET NULL
);

-- 3. Таблица Трансфери (Етап 4)
CREATE TABLE Transfers (
    transfer_id INT AUTO_INCREMENT PRIMARY KEY,
    player_id INT NOT NULL,
    from_team_id INT,
    to_team_id INT NOT NULL,
    transfer_fee DECIMAL(15,2) DEFAULT 0,
    transfer_date DATE NOT NULL,
    FOREIGN KEY (player_id) REFERENCES Players(player_id) ON DELETE CASCADE,
    FOREIGN KEY (from_team_id) REFERENCES Teams(team_id) ON DELETE SET NULL,
    FOREIGN KEY (to_team_id) REFERENCES Teams(team_id) ON DELETE CASCADE
);

-- 4. Таблица Лиги (Етап 5)
CREATE TABLE Leagues (
    league_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    season VARCHAR(9) NOT NULL,
    CONSTRAINT unique_league_season UNIQUE (name, season)
);

-- 5. Свързваща таблица Участници в Лиги (Много-към-много)
CREATE TABLE league_teams (
    league_id INT NOT NULL,
    team_id INT NOT NULL,
    PRIMARY KEY (league_id, team_id),
    FOREIGN KEY (league_id) REFERENCES Leagues(league_id) ON DELETE CASCADE,
    FOREIGN KEY (team_id) REFERENCES Teams(team_id) ON DELETE CASCADE
);

-- 6. Таблица Мачове (Етап 6)
CREATE TABLE Matches (
    match_id INT AUTO_INCREMENT PRIMARY KEY,
    league_id INT NOT NULL,
    round_no INT NOT NULL,
    home_team_id INT NOT NULL,
    away_team_id INT NOT NULL,
    home_score INT NULL, -- NULL означава, че мачът още не е изигран
    away_score INT NULL,
    match_date DATE NOT NULL,
    FOREIGN KEY (league_id) REFERENCES Leagues(league_id) ON DELETE CASCADE,
    FOREIGN KEY (home_team_id) REFERENCES Teams(team_id) ON DELETE CASCADE,
    FOREIGN KEY (away_team_id) REFERENCES Teams(team_id) ON DELETE CASCADE
);

-- Добавяме Стадион към мачовете
ALTER TABLE Matches ADD COLUMN IF NOT EXISTS stadium VARCHAR(100);

-- Създаваме обединена таблица за всички събития (Гол, Картон, Фал)
CREATE TABLE IF NOT EXISTS MatchEvents (
    event_id INT AUTO_INCREMENT PRIMARY KEY,
    match_id INT NOT NULL,
    player_id INT NOT NULL,
    team_id INT NOT NULL,
    minute INT NOT NULL CHECK (minute >= 1 AND minute <= 120),
    event_type VARCHAR(50) NOT NULL, -- Тук ще пише 'Гол', 'Жълт картон', 'Червен картон' или 'Фал'
    FOREIGN KEY (match_id) REFERENCES Matches(match_id) ON DELETE CASCADE,
    FOREIGN KEY (player_id) REFERENCES Players(player_id) ON DELETE CASCADE,
    FOREIGN KEY (team_id) REFERENCES Teams(team_id) ON DELETE CASCADE
);
