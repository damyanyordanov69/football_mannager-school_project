-- Създаване на базата данни, ако не съществува
CREATE DATABASE IF NOT EXISTS football_manager;
USE football_manager;

-- 1. Лиги
CREATE TABLE Leagues (
    league_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL UNIQUE
);

-- 2. Отбори
CREATE TABLE Teams (
    team_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL,
    city VARCHAR(50),
    league_id INT,
    FOREIGN KEY (league_id) REFERENCES Leagues(league_id)
);

-- 3. Играчи (ОБНОВЕНА за Етап 3)
CREATE TABLE Players (
    player_id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    birth_date DATE NOT NULL,       -- Дата на раждане
    position VARCHAR(5) NOT NULL,   -- Позиция (GK, DF, MF, FW)
    team_id INT,
    FOREIGN KEY (team_id) REFERENCES Teams(team_id)
);

-- 4. Мачове
CREATE TABLE Matches (
    match_id INT PRIMARY KEY AUTO_INCREMENT,
    home_team_id INT,
    away_team_id INT,
    home_score INT DEFAULT 0 CHECK (home_score >= 0),
    away_score INT DEFAULT 0 CHECK (away_score >= 0),
    match_date DATE,
    FOREIGN KEY (home_team_id) REFERENCES Teams(team_id),
    FOREIGN KEY (away_team_id) REFERENCES Teams(team_id)
);

-- 5. Трансфери
CREATE TABLE Transfers (
    transfer_id INT PRIMARY KEY AUTO_INCREMENT,
    player_id INT NOT NULL,
    from_team_id INT,
    to_team_id INT NOT NULL,
    transfer_fee DECIMAL(15, 2) DEFAULT 0.00,
    transfer_date DATE NOT NULL,
    FOREIGN KEY (player_id) REFERENCES Players(player_id),
    FOREIGN KEY (from_team_id) REFERENCES Teams(team_id),
    FOREIGN KEY (to_team_id) REFERENCES Teams(team_id)
);

-- Обновяване на таблица Лиги (Добавяне на Сезон)
ALTER TABLE Leagues ADD COLUMN IF NOT EXISTS season VARCHAR(9) NOT NULL DEFAULT '2023/2024';
ALTER TABLE Leagues ADD CONSTRAINT unique_league_season UNIQUE (name, season);

-- Свързваща таблица за Участниците (Много-към-много)
CREATE TABLE IF NOT EXISTS league_teams (
    league_id INT NOT NULL,
    team_id INT NOT NULL,
    PRIMARY KEY (league_id, team_id),
    FOREIGN KEY (league_id) REFERENCES Leagues(league_id) ON DELETE CASCADE,
    FOREIGN KEY (team_id) REFERENCES Teams(team_id) ON DELETE CASCADE
);
