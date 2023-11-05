-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Nov 05, 2023 at 12:37 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `TouristDB`
--

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoleClaims`
--

CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoles`
--

CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserClaims`
--

CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserLogins`
--

CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserRoles`
--

CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUsers`
--

CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) NOT NULL,
  `Role` longtext DEFAULT NULL,
  `FullName` longtext DEFAULT NULL,
  `DeviceToken` longtext DEFAULT NULL,
  `Status` longtext DEFAULT NULL,
  `Code` longtext DEFAULT NULL,
  `Gender` longtext DEFAULT NULL,
  `City` longtext DEFAULT NULL,
  `Birth` datetime(6) DEFAULT NULL,
  `Points` double DEFAULT NULL,
  `Lat` double DEFAULT NULL,
  `Lng` double DEFAULT NULL,
  `SurveysBalance` double DEFAULT NULL,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserTokens`
--

CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Cities`
--

CREATE TABLE `Cities` (
  `Id` int(11) NOT NULL,
  `CountryId` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL,
  `status` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `IsMostPopular` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Cities`
--

INSERT INTO `Cities` (`Id`, `CountryId`, `Title`, `Image`, `status`, `CreatedAt`, `IsMostPopular`) VALUES
(16, 16, 'ميونخ', '20230321T131529.jpeg', 0, '2023-02-03 21:25:24.344862', 1),
(18, 16, 'هامبورج', '20230321T131627.jpeg', 0, '2023-02-03 21:26:57.576186', 0),
(19, 16, 'لايبزيغ', '20230321T054942.jpeg', 0, '2023-02-03 21:27:25.696024', 0),
(34, 17, 'Sohage', '20230321T131517.jpeg', 0, '2023-03-21 13:03:32.827603', 1),
(36, 0, ' updatetest', '20230927T124904.jpeg', 0, '2023-09-27 12:49:06.717338', 0);

-- --------------------------------------------------------

--
-- Table structure for table `Continents`
--

CREATE TABLE `Continents` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL,
  `status` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Continents`
--

INSERT INTO `Continents` (`Id`, `Name`, `Image`, `status`, `CreatedAt`) VALUES
(25, 'أوروبا', '20230925T140555.jpeg', 0, '0001-01-01 00:00:00.000000'),
(28, 'استراليا', '20230925T140740.jpeg', 0, '0001-01-01 00:00:00.000000'),
(34, 'أفريقيا', '20230925T140839.jpeg', 0, '0001-01-01 00:00:00.000000'),
(35, 'أسيا', '20230925T140904.jpeg', 0, '0001-01-01 00:00:00.000000');

-- --------------------------------------------------------

--
-- Table structure for table `Countries`
--

CREATE TABLE `Countries` (
  `Id` int(11) NOT NULL,
  `ContinentId` int(11) NOT NULL,
  `Language` longtext DEFAULT NULL,
  `Currency` longtext DEFAULT NULL,
  `Name` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL,
  `status` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `Capital` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Countries`
--

INSERT INTO `Countries` (`Id`, `ContinentId`, `Language`, `Currency`, `Name`, `Image`, `status`, `CreatedAt`, `Capital`) VALUES
(16, 25, 'الالمانية', 'يورو', 'ألمانيا', '20230203T211608.jpeg', 0, '2023-02-03 21:16:08.113963', 'برلين'),
(17, 25, 'English', 'دولار', 'المجر', '20230203T211818.jpeg', 0, '2023-02-03 21:18:18.030467', 'المجر'),
(18, 25, 'English', 'روبيه', 'سويسرا', '20230203T211941.jpeg', 0, '2023-02-03 21:19:41.562270', 'برن'),
(19, 25, 'English', 'هريفنا', 'أوكرانيا', '20230203T212144.jpeg', 0, '2023-02-03 21:21:44.739765', 'كييف'),
(20, 25, 'English', 'كرونه سويدية', 'السويد', '20230203T212249.jpeg', 0, '2023-02-03 21:22:49.981165', '	ستوكهولم'),
(21, 25, 'English', 'يورو', 'أسبانيا', '20230203T212415.jpeg', 0, '2023-02-03 21:24:15.535921', 'مدريد'),
(22, 25, 'الفرنسية', 'دولار', 'فرنسا', '20230203T220421.jpeg', 0, '2023-02-03 22:04:21.534070', 'باريس');

-- --------------------------------------------------------

--
-- Table structure for table `Favorites`
--

CREATE TABLE `Favorites` (
  `Id` int(11) NOT NULL,
  `PlaceId` int(11) NOT NULL,
  `Likes` double NOT NULL,
  `UpdatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Photos`
--

CREATE TABLE `Photos` (
  `Id` int(11) NOT NULL,
  `PlaceId` int(11) NOT NULL,
  `image` longtext DEFAULT NULL,
  `CityId` int(11) NOT NULL DEFAULT 0,
  `Type` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Photos`
--

INSERT INTO `Photos` (`Id`, `PlaceId`, `image`, `CityId`, `Type`) VALUES
(45, 20, '20230303T184707.jpeg', 19, 0),
(46, 20, '20230303T185034.jpeg', 19, 0),
(50, 0, '20230409T111930.jpeg', 16, 0),
(51, 0, '20230409T112500.jpeg', 16, 0),
(52, 20, '73595.mp4', 16, 1),
(56, 23, '20230409T154517.jpeg', 16, 0),
(57, 24, '20230903T233708.jpeg', 34, 0),
(58, 25, '20230904T003843.jpeg', 16, 0),
(59, 26, '20230927T130845.jpeg', 16, 0);

-- --------------------------------------------------------

--
-- Table structure for table `Places`
--

CREATE TABLE `Places` (
  `Id` int(11) NOT NULL,
  `CountryId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Desc` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL,
  `status` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `Order` int(11) NOT NULL DEFAULT 0,
  `AddressName` longtext DEFAULT NULL,
  `LatLng` longtext NOT NULL,
  `IsMostPopular` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Places`
--

INSERT INTO `Places` (`Id`, `CountryId`, `CityId`, `Title`, `Desc`, `Image`, `status`, `CreatedAt`, `Order`, `AddressName`, `LatLng`, `IsMostPopular`) VALUES
(15, 16, 16, 'متحف', 'متحف  سياحى', '20230904T085332.jpeg', 0, '2023-02-03 21:31:36.736168', 1, 'برديس العساكرة مركز البلينا سوهاج 1616245', '26.286459907517575, 31.946705948068747', 1),
(16, 16, 16, 'مكان ترفيهى', 'مكان ترفيهى مكان ترفيهى مكان ترفيهى ر ر رمكان ترفيهىمكان ترفيهىمكان ترفيهىمكان ترفيهىمكان ترفيهى', '20230927T121549.jpeg', 0, '2023-02-03 21:32:52.244033', 2, 'سوهاج الخولي قسم أول سوهاج', '26.559231043419953, 31.696313031041413', 1),
(20, 16, 16, 'sd', 'dsfsfds', '20230409T153736.jpeg', 0, '2023-04-09 15:37:36.858190', 0, 'سوهاج الخولي قسم أول سوهاج سوهاج', '26.558341210045768, 31.697307840601756', 0),
(22, 16, 16, ' cffd', 'ssss', '20230409T154221.jpeg', 0, '2023-04-09 15:42:21.869111', 4, 'سوهاج الخولي قسم أول سوهاج سوهاج', '26.558595448857552, 31.698018418859135', 0),
(24, 0, 0, 'fcfxgv', 'ggfdgdfgdfgdf', '20230903T233708.jpeg', 0, '2023-09-03 23:37:08.822602', 4, 'سوهاج الخولي قسم أول سوهاج سوهاج', '26.559612398465635, 31.698018418859135', 0),
(25, 16, 16, 'fds', 'fdgvdsfgds', '20230904T003843.jpeg', 0, '2023-09-04 00:38:43.046007', -1, 'الجيزة، قسم العمرانية، الجيزة', '30.01143077269031, 31.20766845617835', 0),
(26, 16, 16, 'test', 'trefdg', '20230927T130845.jpeg', 0, '2023-09-27 13:08:45.922411', -1, 'ggdfgd', '4544,54554', 1);

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20221229200617_Initi1', '6.0.10'),
('20230103214936_Initi2', '6.0.10'),
('20230128195227_Initi12', '6.0.10'),
('20230128195519_Initi10', '6.0.10'),
('20230128195925_Initi11', '6.0.10'),
('20230131163745_Initi5', '6.0.10'),
('20230303153219_InitialCreat', '6.0.10'),
('20230320165922_InitialCreat3', '6.0.10'),
('20230321141401_InitialCreat5', '6.0.10'),
('20230903205447_InitialCreate', '6.0.10'),
('20230903212238_InitialCreate1', '6.0.10'),
('20230903213332_InitialCreate2', '6.0.10'),
('20230924094410_InitialCreate3', '6.0.10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetRoles`
--
ALTER TABLE `AspNetRoles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetUsers`
--
ALTER TABLE `AspNetUsers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `Cities`
--
ALTER TABLE `Cities`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Continents`
--
ALTER TABLE `Continents`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Countries`
--
ALTER TABLE `Countries`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Favorites`
--
ALTER TABLE `Favorites`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Photos`
--
ALTER TABLE `Photos`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Places`
--
ALTER TABLE `Places`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Cities`
--
ALTER TABLE `Cities`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `Continents`
--
ALTER TABLE `Continents`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;

--
-- AUTO_INCREMENT for table `Countries`
--
ALTER TABLE `Countries`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `Favorites`
--
ALTER TABLE `Favorites`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Photos`
--
ALTER TABLE `Photos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=60;

--
-- AUTO_INCREMENT for table `Places`
--
ALTER TABLE `Places`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
