CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  name varchar(255) NOT NULL COMMENT 'Keep Name',
  description varchar(5000) DEFAULT 'Description not provided...' COMMENT 'Keep Description',
  img varchar(500) COMMENT 'Keep Image',
  views INT DEFAULT 0 COMMENT 'Keep View Count',
  shares INT DEFAULT 0 COMMENT 'Keep Share Count',
  keeps INT DEFAULT 0 COMMENT 'Keep Saved Count',
  creatorId VARCHAR(255) NOT NULL COMMENT 'Account Id for Creator',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  name varchar(255) NOT NULL COMMENT 'Vault Name',
  description varchar(5000) DEFAULT 'Description not provided...' COMMENT 'Vault Description',
  isPrivate TINYINT COMMENT 'Bool Value for Private',
  creatorId VARCHAR(255) NOT NULL COMMENT 'Account Id for Creator',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS vaultKeeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  creatorId VARCHAR(255) NOT NULL COMMENT 'Account Id for Creator',
  vaultId INT NOT NULL COMMENT 'Vault Id',
  keepId INT NOT NULL COMMENT 'Vault Id',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';