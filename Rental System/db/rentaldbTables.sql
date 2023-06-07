SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

CREATE DATABASE IF NOT EXISTS `rentaldb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `rentaldb`;

CREATE TABLE IF NOT EXISTS `qrental` (
`id` int(11)
,`transno` varchar(50)
,`cid` int(11)
,`fullname` varchar(250)
,`plateno` varchar(50)
,`dborrowed` date
,`dreturned` date
,`rental` decimal(10,0)
,`rentalpay` decimal(10,0)
,`remarks` text
,`status` varchar(50)
);

CREATE TABLE IF NOT EXISTS `tblbrand` (
  `brand` varchar(50) NOT NULL,
  PRIMARY KEY (`brand`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE IF NOT EXISTS `tblcustomer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(250) NOT NULL,
  `address` text NOT NULL,
  `bdate` date NOT NULL,
  `contact` varchar(100) NOT NULL,
  `idtype` varchar(50) NOT NULL,
  `idno` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

CREATE TABLE IF NOT EXISTS `tblmotor` (
  `plate` varchar(50) NOT NULL,
  `brand` varchar(50) NOT NULL,
  `model` varchar(50) NOT NULL,
  `color` varchar(50) NOT NULL,
  `rental` double NOT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'Available',
  PRIMARY KEY (`plate`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `tblpayment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `transno` varchar(50) NOT NULL,
  `name` text NOT NULL,
  `cash` double NOT NULL,
  `sdate` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=14 ;

CREATE TABLE IF NOT EXISTS `tblrent` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `transno` varchar(50) NOT NULL,
  `cid` int(11) NOT NULL,
  `plateno` varchar(50) NOT NULL,
  `dborrowed` date NOT NULL,
  `dreturned` date NOT NULL,
  `rental` decimal(10,0) NOT NULL,
  `noofdays` int(11) NOT NULL,
  `rentalpay` decimal(10,0) NOT NULL,
  `remarks` text NOT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'Borrowed',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=33 ;

DROP TABLE IF EXISTS `qrental`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `qrental` AS select `r`.`id` AS `id`,`r`.`transno` AS `transno`,`r`.`cid` AS `cid`,`b`.`fullname` AS `fullname`,`r`.`plateno` AS `plateno`,`r`.`dborrowed` AS `dborrowed`,`r`.`dreturned` AS `dreturned`,`r`.`rental` AS `rental`,`r`.`rentalpay` AS `rentalpay`,`r`.`remarks` AS `remarks`,`r`.`status` AS `status` from (`tblrent` `r` join `tblcustomer` `b` on((`b`.`id` = `r`.`cid`)));

CREATE TABLE IF NOT EXISTS `tbladmin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(250) NOT NULL,
  `address` text NOT NULL,
  `bdate` date NOT NULL,
  `contact` varchar(100) NOT NULL,
  `idtype` varchar(50) NOT NULL,
  `idno` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;
