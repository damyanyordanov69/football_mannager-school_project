CREATE DATABASE IF NOT EXISTS football_mannager;

USE football_mannager;

CREATE TABLE Leagues (
    league_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Teams (
    team_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL,
    city VARCHAR(50),
    league_id INT,
    FOREIGN KEY (league_id) REFERENCES Leagues(league_id)
);

CREATE TABLE Players (
    player_id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    age INT CHECK (age >= 16),
    team_id INT,
    FOREIGN KEY (team_id) REFERENCES Teams(team_id)
);

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

-- НОВА ТАБЛИЦА: Трансфери
CREATE TABLE Transfers (
    transfer_id INT PRIMARY KEY AUTO_INCREMENT,
    player_id INT NOT NULL,
    from_team_id INT,
    to_team_id INT NOT NULL,
    transfer_fee DECIMAL(15, 2) DEFAULT 0.00, -- Сума на трансфера
    transfer_date DATE NOT NULL,
    FOREIGN KEY (player_id) REFERENCES Players(player_id),
    FOREIGN KEY (from_team_id) REFERENCES Teams(team_id),
    FOREIGN KEY (to_team_id) REFERENCES Teams(team_id)
);