CREATE DATABASE IF NOT EXISTS `pwa_buffet` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `pwa_buffet`;
-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: pwa_buffet
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20210517224119_pwa_buffet','5.0.6');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` char(36) NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 ,
  `ClaimValue` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` char(36) NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4  DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4  DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` char(36) NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 ,
  `ClaimValue` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 ,
  `UserId` char(36) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` char(36) NOT NULL,
  `RoleId` char(36) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` char(36) NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4  DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4  DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4  DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4  DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 ,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 ,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 ,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 ,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('08d91985-043e-413d-8ee7-a019a9db37da','admin@gmail.com','ADMIN@GMAIL.COM','admin@gmail.com','ADMIN@GMAIL.COM',0,'AQAAAAEAACcQAAAAEDOudnHd11cvDppf3+HITu6MEKdzr2yh8pTVpGMP1o1ZW7z1sQEjVGLUPbm0DNNH4Q==','XKHHQ5T6XJQEZPKOCJ67VUJJLCU4PFRU','b51adaf3-1c2c-456d-8cb1-c2ab6d5e2262',NULL,0,0,NULL,1,0),('08d91986-0370-433a-89b0-8d312ff05274','teste@gmail.com','TESTE@GMAIL.COM','teste@gmail.com','TESTE@GMAIL.COM',0,'AQAAAAEAACcQAAAAEDtD/0GmErGY+JinqESnCXqHw4TDfKetRFPIUZDccz3A2NFkqU1U3AvLIbn4FvPOkw==','TNFJXCHTL4VIFPA753OUAEDGN34MFZQD','2444fc46-d979-44a7-9da8-619f45edc765',NULL,0,0,NULL,1,0),('08d91a4a-c774-4a6f-84fb-4e586b129f87','lili@gmail.com','LILI@GMAIL.COM','lili@gmail.com','LILI@GMAIL.COM',0,'AQAAAAEAACcQAAAAEHMfrR+s+trth2yfihfXG1+beQaOuTR62r9Qms1wtoTk2WLhn0X0rlCk5soNJRR5IA==','6SOJ6QDQCNLHZWPFENXHUK562GE4DHAA','bf6d9cb4-4866-4ba0-ba86-3a46fd7b73fd',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` char(36) NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4  NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `Id` char(36) NOT NULL,
  `Nome` longtext CHARACTER SET utf8mb4  NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4  NOT NULL,
  `Endereco` longtext CHARACTER SET utf8mb4  NOT NULL,
  `Observacoes` longtext CHARACTER SET utf8mb4 ,
  `CPF` varchar(14) CHARACTER SET utf8mb4  DEFAULT NULL,
  `DataNasc` datetime(6) NOT NULL,
  `CNPJ` varchar(18) CHARACTER SET utf8mb4  DEFAULT NULL,
  `TipoClienteId` char(36) DEFAULT NULL,
  `RegistroDataInsert` datetime(6) NOT NULL,
  `RegistroDataUpdate` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Cliente_TipoClienteId` (`TipoClienteId`),
  CONSTRAINT `FK_Cliente_TipoCliente_TipoClienteId` FOREIGN KEY (`TipoClienteId`) REFERENCES `tipocliente` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES ('3d2b3e15-81e4-4828-aac0-da30d36f35f2','teste','teste123@gmail.com','teste','teste','000.000.000-00','1993-02-01 00:00:00.000000',NULL,'5ba96650-b761-11eb-a494-a8a15927affd','2021-05-18 19:09:28.116649','2021-05-18 19:18:59.059896'),('abc911d2-81d4-4f32-ac10-990822df21b2','Williane Oliveira','wop.vet@gmail.com','minha casa, minha vida','teste','111.111.111-11','1993-02-01 00:00:00.000000',NULL,'5ba96650-b761-11eb-a494-a8a15927affd','2021-05-17 19:44:17.863304','2021-05-18 19:18:49.869673'),('b0124ea6-2df5-4767-b2e2-39a64107fbe4','testeclientePJ','pj@gmail.com','teste',NULL,NULL,'0001-01-01 00:00:00.000000','22.222.222/2222-22','5ba95ac9-b761-11eb-a494-a8a15927affd','2021-05-18 20:08:44.306819','2021-05-18 20:14:40.425479'),('b30cf7e7-ed62-46be-9109-b928636d8638','Ello Joias','ellojoias@gmail.com','Rua Batista de Oliveira, 150','Joalheria Handmade.',NULL,'0001-01-01 00:00:00.000000','12.345.678/9000-00','5ba95ac9-b761-11eb-a494-a8a15927affd','2021-05-17 19:45:27.607188',NULL);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `convidado`
--

DROP TABLE IF EXISTS `convidado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `convidado` (
  `Id` char(36) NOT NULL,
  `Nome` longtext CHARACTER SET utf8mb4  NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4  NOT NULL,
  `CPF` varchar(14) CHARACTER SET utf8mb4  NOT NULL,
  `DataNasc` datetime(6) NOT NULL,
  `EventoId` char(36) DEFAULT NULL,
  `SituacaoConvidadoId` char(36) DEFAULT NULL,
  `Observacoes` longtext CHARACTER SET utf8mb4 ,
  `RegistroDataInsert` datetime(6) NOT NULL,
  `RegistroDataUpdate` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Convidado_EventoId` (`EventoId`),
  KEY `IX_Convidado_SituacaoConvidadoId` (`SituacaoConvidadoId`),
  CONSTRAINT `FK_Convidado_Evento_EventoId` FOREIGN KEY (`EventoId`) REFERENCES `evento` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Convidado_SituacaoConvidado_SituacaoConvidadoId` FOREIGN KEY (`SituacaoConvidadoId`) REFERENCES `situacaoconvidado` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `convidado`
--

LOCK TABLES `convidado` WRITE;
/*!40000 ALTER TABLE `convidado` DISABLE KEYS */;
INSERT INTO `convidado` VALUES ('08d91a52-f1a0-49fa-84e6-c9ea87d9fea1','testeconvidado','teste123@gmail.com','888.888.888-88','1991-01-01 00:00:00.000000','08d91985-d907-43dc-8de2-3ed6e16a0615','c0834b0f-b761-11eb-a494-a8a15927affd','teste','2021-05-18 20:16:19.301302',NULL);
/*!40000 ALTER TABLE `convidado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evento`
--

DROP TABLE IF EXISTS `evento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evento` (
  `Id` char(36) NOT NULL,
  `Nome` longtext CHARACTER SET utf8mb4  NOT NULL,
  `ClienteId` char(36) DEFAULT NULL,
  `TipoEventoId` char(36) DEFAULT NULL,
  `Descricao` longtext CHARACTER SET utf8mb4 ,
  `DataHoraInicio` datetime(6) NOT NULL,
  `DataHoraFim` datetime(6) NOT NULL,
  `SituacaoEventoId` char(36) DEFAULT NULL,
  `LocalId` char(36) DEFAULT NULL,
  `Observacoes` longtext CHARACTER SET utf8mb4 ,
  `RegistroDataInsert` datetime(6) NOT NULL,
  `RegistroDataUpdate` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Evento_ClienteId` (`ClienteId`),
  KEY `IX_Evento_LocalId` (`LocalId`),
  KEY `IX_Evento_SituacaoEventoId` (`SituacaoEventoId`),
  KEY `IX_Evento_TipoEventoId` (`TipoEventoId`),
  CONSTRAINT `FK_Evento_Cliente_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Evento_Local_LocalId` FOREIGN KEY (`LocalId`) REFERENCES `local` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Evento_SituacaoEvento_SituacaoEventoId` FOREIGN KEY (`SituacaoEventoId`) REFERENCES `situacaoevento` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Evento_TipoEvento_TipoEventoId` FOREIGN KEY (`TipoEventoId`) REFERENCES `tipoevento` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evento`
--

LOCK TABLES `evento` WRITE;
/*!40000 ALTER TABLE `evento` DISABLE KEYS */;
INSERT INTO `evento` VALUES ('08d91985-d907-43dc-8de2-3ed6e16a0615','Festa de aniversário','abc911d2-81d4-4f32-ac10-990822df21b2','c312cbbb-b761-11eb-a494-a8a15927affd','Festa de aniversário - Williane','2022-02-01 20:00:00.000000','2022-02-02 04:00:00.000000','c083c140-b761-11eb-a494-a8a15927affd','4d0209fb-e348-40dc-967b-a9320adc43fe','Traje casual.','2021-05-17 19:48:11.207000','2021-05-18 20:15:05.973471'),('08d91a4b-1c4b-4514-84ad-3e1f05588939','Festa de celebração','b30cf7e7-ed62-46be-9109-b928636d8638','c312cd00-b761-11eb-a494-a8a15927affd','Festa de celebração de 30 anos da empresa.','2021-07-12 19:00:00.000000','2021-07-13 06:00:00.000000','c083c140-b761-11eb-a494-a8a15927affd','9aa90e6e-169e-433e-b74c-932a5ed2918f','Celebração de 30 anos da empresa.','2021-05-18 19:20:14.919413',NULL);
/*!40000 ALTER TABLE `evento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historicologin`
--

DROP TABLE IF EXISTS `historicologin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `historicologin` (
  `Id` char(36) NOT NULL,
  `DataHoraLogin` datetime(6) NOT NULL,
  `UsuarioId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_HistoricoLogin_UsuarioId` (`UsuarioId`),
  CONSTRAINT `FK_HistoricoLogin_AspNetUsers_UsuarioId` FOREIGN KEY (`UsuarioId`) REFERENCES `aspnetusers` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historicologin`
--

LOCK TABLES `historicologin` WRITE;
/*!40000 ALTER TABLE `historicologin` DISABLE KEYS */;
INSERT INTO `historicologin` VALUES ('00d958b5-df80-4911-92e1-da8a6398d644','2021-05-18 16:48:34.977354','08d91986-0370-433a-89b0-8d312ff05274'),('0178211a-0294-464d-88d5-4563c26903e7','2021-05-17 19:49:30.806600','08d91986-0370-433a-89b0-8d312ff05274'),('027563cc-4f3b-4619-848b-315732071329','2021-05-18 16:48:58.429747','08d91986-0370-433a-89b0-8d312ff05274'),('0277e684-a574-4e05-8f93-f71e200f2e1d','2021-05-18 19:23:25.918494','08d91a4a-c774-4a6f-84fb-4e586b129f87'),('0395d74b-7008-4f27-8970-922c4baf41ba','2021-05-18 17:08:34.422889','08d91986-0370-433a-89b0-8d312ff05274'),('067a6307-7000-4072-8b43-b8577084448d','2021-05-18 16:46:52.772741','08d91986-0370-433a-89b0-8d312ff05274'),('0f8db111-2e49-4498-83b0-8ab8208e94a1','2021-05-17 19:51:12.930311','08d91986-0370-433a-89b0-8d312ff05274'),('10d97b28-dfcc-4581-b352-1879f9fddb1c','2021-05-18 19:24:45.894742','08d91a4a-c774-4a6f-84fb-4e586b129f87'),('11691cd5-a2a8-451e-bd77-8ffee8d06378','2021-05-18 16:42:00.723226','08d91986-0370-433a-89b0-8d312ff05274'),('12d3fadc-1236-4ce7-8c14-6b126ac9233e','2021-05-18 18:30:36.037988','08d91986-0370-433a-89b0-8d312ff05274'),('130cb0fe-1f17-452c-a2f1-fdfa383970c8','2021-05-18 18:49:32.830765','08d91986-0370-433a-89b0-8d312ff05274'),('1636fe25-fb39-4753-91f4-c66961f1e893','2021-05-18 18:07:08.379856','08d91986-0370-433a-89b0-8d312ff05274'),('1eb8162c-c6db-4159-be47-a17c1ebd269f','2021-05-18 16:57:42.190734','08d91986-0370-433a-89b0-8d312ff05274'),('22a3218a-575a-4501-ad86-34df3fcb7ee1','2021-05-18 20:14:24.692104','08d91986-0370-433a-89b0-8d312ff05274'),('29dacb8c-bc09-4324-b9bc-4410a0760cec','2021-05-18 17:00:48.942835','08d91986-0370-433a-89b0-8d312ff05274'),('330936fd-8900-46c4-85ac-2512ca257c3c','2021-05-18 18:24:34.799814','08d91986-0370-433a-89b0-8d312ff05274'),('375c1f29-0421-4e50-85b0-1689994ebc29','2021-05-18 18:42:45.472184','08d91986-0370-433a-89b0-8d312ff05274'),('39ef8366-e5f8-4229-90b5-e75ba282b9cc','2021-05-18 16:47:38.067958','08d91986-0370-433a-89b0-8d312ff05274'),('4465c154-40e9-43e7-8954-0bacb47967ad','2021-05-18 17:04:59.573313','08d91986-0370-433a-89b0-8d312ff05274'),('45582a72-b167-498e-8399-14796dee4ec9','2021-05-18 20:08:08.362070','08d91a4a-c774-4a6f-84fb-4e586b129f87'),('4d4ebfaa-688d-4d98-bb6b-ff81f9f9f9d3','2021-05-18 19:13:23.857330','08d91986-0370-433a-89b0-8d312ff05274'),('4f3b19c4-9b68-4759-a26e-27ec941356f1','2021-05-18 16:46:14.923652','08d91986-0370-433a-89b0-8d312ff05274'),('52cca420-73d7-435e-998f-d1c8f83eec69','2021-05-18 18:41:05.786445','08d91986-0370-433a-89b0-8d312ff05274'),('657a5a4a-7bbb-40fb-bc95-bc2a0aa4c146','2021-05-18 16:47:13.658764','08d91986-0370-433a-89b0-8d312ff05274'),('67f750be-3b84-4866-afc9-7645bde793aa','2021-05-18 16:40:47.328278','08d91986-0370-433a-89b0-8d312ff05274'),('68825a67-5672-4200-a74e-c1fc69d39857','2021-05-18 18:04:45.878578','08d91986-0370-433a-89b0-8d312ff05274'),('6c218706-9c55-4a57-a841-90895060d8d3','2021-05-18 16:45:41.606314','08d91986-0370-433a-89b0-8d312ff05274'),('6cc83360-082b-41ec-8e53-d2ac616858c0','2021-05-18 18:14:19.831564','08d91986-0370-433a-89b0-8d312ff05274'),('71d39129-a309-40f3-aac5-26ae7ad8bea4','2021-05-18 18:29:33.816328','08d91986-0370-433a-89b0-8d312ff05274'),('74b857bc-318c-4344-a42d-84a873a1b112','2021-05-18 16:56:42.735845','08d91986-0370-433a-89b0-8d312ff05274'),('783b9094-98e2-4bd9-9213-03af6ba8ad08','2021-05-18 16:58:43.297605','08d91986-0370-433a-89b0-8d312ff05274'),('79059855-6850-4cf8-883b-9b5d6444936d','2021-05-17 19:42:21.072364','08d91985-043e-413d-8ee7-a019a9db37da'),('7e0c7efe-b1df-47ad-8f5b-727b96ec0919','2021-05-18 18:55:19.996410','08d91986-0370-433a-89b0-8d312ff05274'),('7f7d0872-18bf-40c8-af82-c01e06b703c6','2021-05-18 16:52:09.147680','08d91986-0370-433a-89b0-8d312ff05274'),('825d35ba-a9ce-462e-8c92-4346e8bcc645','2021-05-18 18:09:14.663944','08d91986-0370-433a-89b0-8d312ff05274'),('8322851b-1722-4c69-9745-4b360d5508a8','2021-05-18 19:09:11.588266','08d91986-0370-433a-89b0-8d312ff05274'),('929eea6b-b075-4ba4-bafb-0e0b0d5b8028','2021-05-18 16:52:42.301150','08d91986-0370-433a-89b0-8d312ff05274'),('931ad4fb-9d98-41d2-b83c-77ff4bebd41b','2021-05-18 17:01:15.444523','08d91986-0370-433a-89b0-8d312ff05274'),('9504840c-46ab-419f-8de6-7552405ce1be','2021-05-18 19:18:12.854153','08d91a4a-c774-4a6f-84fb-4e586b129f87'),('95b1260a-daf3-4d37-b72f-787d55335b98','2021-05-18 18:55:55.840126','08d91986-0370-433a-89b0-8d312ff05274'),('9f647a49-0c99-4736-97c0-ae6c3b44fe98','2021-05-18 18:20:19.103397','08d91986-0370-433a-89b0-8d312ff05274'),('a963697a-0e97-4b54-89e4-9e0527d8ac18','2021-05-18 18:27:44.700648','08d91986-0370-433a-89b0-8d312ff05274'),('b0e8cd90-868f-4f87-b552-50020ecc4528','2021-05-18 17:06:59.384805','08d91986-0370-433a-89b0-8d312ff05274'),('c24027ea-25f3-446b-8fc7-a9d52c55dcc1','2021-05-18 18:16:57.721805','08d91986-0370-433a-89b0-8d312ff05274'),('c43e5f42-80a2-4ebb-8f06-541d198ea68d','2021-05-18 18:38:49.601735','08d91986-0370-433a-89b0-8d312ff05274'),('cafacca9-9e84-4b12-aafb-b208f73ffbc2','2021-05-18 17:06:04.872649','08d91986-0370-433a-89b0-8d312ff05274'),('d3e86f5d-c192-4de6-ad44-7f5be69a40de','2021-05-18 20:22:27.833085','08d91985-043e-413d-8ee7-a019a9db37da'),('d5b157f3-7add-44b4-babe-89186cccad30','2021-05-18 18:33:42.886262','08d91986-0370-433a-89b0-8d312ff05274'),('d5bf8c4e-7188-49b5-9dee-8302946d26f8','2021-05-18 16:55:15.125649','08d91986-0370-433a-89b0-8d312ff05274'),('d665fb4e-338e-451d-afe6-ef3f7cce25b3','2021-05-18 17:03:05.835620','08d91986-0370-433a-89b0-8d312ff05274'),('d8a9d2af-b1f2-4131-8ddd-a93ab7438d01','2021-05-18 18:12:02.705502','08d91986-0370-433a-89b0-8d312ff05274'),('e0168f09-1069-41ba-9ea7-0568e59df7b6','2021-05-18 16:44:01.970953','08d91986-0370-433a-89b0-8d312ff05274'),('e1f049c2-f985-41c0-bbf5-23ed1d1e943f','2021-05-18 18:37:24.439819','08d91986-0370-433a-89b0-8d312ff05274'),('ef2608a2-ea97-4677-a5dd-e0983a9be7ef','2021-05-18 16:22:53.570375','08d91986-0370-433a-89b0-8d312ff05274'),('f7a37843-8a03-42e1-84fd-bab1a8e936da','2021-05-18 18:44:15.903905','08d91986-0370-433a-89b0-8d312ff05274'),('fe6205dc-f394-4913-a3ef-e3adaa879fa3','2021-05-18 16:48:07.377029','08d91986-0370-433a-89b0-8d312ff05274'),('ffe8f684-be5d-4c3f-ab42-da6c6e179564','2021-05-18 16:49:21.798264','08d91986-0370-433a-89b0-8d312ff05274');
/*!40000 ALTER TABLE `historicologin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `local`
--

DROP TABLE IF EXISTS `local`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `local` (
  `Id` char(36) NOT NULL,
  `Descricao` longtext CHARACTER SET utf8mb4 ,
  `Endereco` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `local`
--

LOCK TABLES `local` WRITE;
/*!40000 ALTER TABLE `local` DISABLE KEYS */;
INSERT INTO `local` VALUES ('4d0209fb-e348-40dc-967b-a9320adc43fe','Espaço Verde','São Pedro, 230'),('9aa90e6e-169e-433e-b74c-932a5ed2918f','Espaço Sirena','Aeroporto, 180');
/*!40000 ALTER TABLE `local` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `situacaoconvidado`
--

DROP TABLE IF EXISTS `situacaoconvidado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `situacaoconvidado` (
  `Id` char(36) NOT NULL,
  `Descricao` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `situacaoconvidado`
--

LOCK TABLES `situacaoconvidado` WRITE;
/*!40000 ALTER TABLE `situacaoconvidado` DISABLE KEYS */;
INSERT INTO `situacaoconvidado` VALUES ('c0834b0f-b761-11eb-a494-a8a15927affd','Confirmado'),('c08366df-b761-11eb-a494-a8a15927affd','À confirmar'),('c08367a2-b761-11eb-a494-a8a15927affd','Negado');
/*!40000 ALTER TABLE `situacaoconvidado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `situacaoevento`
--

DROP TABLE IF EXISTS `situacaoevento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `situacaoevento` (
  `Id` char(36) NOT NULL,
  `Descricao` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `situacaoevento`
--

LOCK TABLES `situacaoevento` WRITE;
/*!40000 ALTER TABLE `situacaoevento` DISABLE KEYS */;
INSERT INTO `situacaoevento` VALUES ('c083c140-b761-11eb-a494-a8a15927affd','Agendado'),('c083cf66-b761-11eb-a494-a8a15927affd','Cancelado'),('c083d14c-b761-11eb-a494-a8a15927affd','Executado');
/*!40000 ALTER TABLE `situacaoevento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipocliente`
--

DROP TABLE IF EXISTS `tipocliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipocliente` (
  `Id` char(36) NOT NULL,
  `Descricao` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipocliente`
--

LOCK TABLES `tipocliente` WRITE;
/*!40000 ALTER TABLE `tipocliente` DISABLE KEYS */;
INSERT INTO `tipocliente` VALUES ('5ba95ac9-b761-11eb-a494-a8a15927affd','Pessoa Jurídica'),('5ba96650-b761-11eb-a494-a8a15927affd','Pessoa Física');
/*!40000 ALTER TABLE `tipocliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoevento`
--

DROP TABLE IF EXISTS `tipoevento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipoevento` (
  `Id` char(36) NOT NULL,
  `Descricao` longtext CHARACTER SET utf8mb4 ,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoevento`
--

LOCK TABLES `tipoevento` WRITE;
/*!40000 ALTER TABLE `tipoevento` DISABLE KEYS */;
INSERT INTO `tipoevento` VALUES ('c312b565-b761-11eb-a494-a8a15927affd','Casamento'),('c312cbbb-b761-11eb-a494-a8a15927affd','Aniversário'),('c312cd00-b761-11eb-a494-a8a15927affd','Evento Social');
/*!40000 ALTER TABLE `tipoevento` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-18 20:24:23
