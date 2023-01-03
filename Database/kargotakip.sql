-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 03 Oca 2023, 16:07:36
-- Sunucu sürümü: 8.0.30
-- PHP Sürümü: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `kargotakip`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `destek_mesaj`
--

CREATE TABLE `destek_mesaj` (
  `mesajId` int NOT NULL,
  `konu` varchar(300) COLLATE utf8mb4_turkish_ci DEFAULT NULL,
  `mesaj` text COLLATE utf8mb4_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `destek_mesaj`
--

INSERT INTO `destek_mesaj` (`mesajId`, `konu`, `mesaj`) VALUES
(1, 'asda', 'sadad'),
(2, 'Kargom nerede', 'asdasdasdasdaskmdkm'),
(3, 'Merhaba', 'sdaadas'),
(4, 'qweqe', 'qweqeqwe'),
(5, 'sistem çöktü', 'asdasda');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `gonderi_takip`
--

CREATE TABLE `gonderi_takip` (
  `gonderiId` int NOT NULL,
  `aliciAdi` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL,
  `aliciSoyadi` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL,
  `takip_no` varchar(4) COLLATE utf8mb4_turkish_ci NOT NULL,
  `durum` varchar(300) COLLATE utf8mb4_turkish_ci NOT NULL,
  `teslim_tipi` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL,
  `teslim_tarih` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `gonderilen_tarih` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `odeme_tipi` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL,
  `gonderen_mail` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci NOT NULL,
  `alici_adres` varchar(400) COLLATE utf8mb4_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `gonderi_takip`
--

INSERT INTO `gonderi_takip` (`gonderiId`, `aliciAdi`, `aliciSoyadi`, `takip_no`, `durum`, `teslim_tipi`, `teslim_tarih`, `gonderilen_tarih`, `odeme_tipi`, `gonderen_mail`, `alici_adres`) VALUES
(1, 'ali', 'can', '1001', 'Teslim edildi', 'seffaf-kargo', '', '', 'kapida-odeme', 'tst@gmail.com', 'Kutahya-Merkez'),
(2, 'a', 'a', '1002', 'İptal edildi', 'Adrese Teslim', '', '', 'Alıcı Tarafından', 'a@a.com', 'a'),
(3, 'asd', 'asd', '', '', 'Adrese Teslim', '', '', 'Gönderici Tarafından', 'asd@sada.com', 'sad'),
(4, 'sad', 'asd', '', '', 'Şubeye Teslim', '', '', 'Alıcı Tarafından', 'qwe@asd.com', 'adsa'),
(5, 'ali', 'Demir', '', '', 'Adrese Teslim', '', '', 'Alıcı Tarafından', 'ahmt@ahmt.com', 'asdadasd'),
(6, 'qwe', 'qwe', '', '', 'Adrese Teslim', '', '', 'Alıcı Tarafından', 'q@q.comq', 'weqqwe'),
(7, 'sabir', 'terzi', '', '', 'Adrese Teslim', '', '', 'Alıcı Tarafından', 'sabir@s.com', 'dasda');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `uyeler`
--

CREATE TABLE `uyeler` (
  `uyeId` int NOT NULL,
  `uyeAdi` varchar(300) COLLATE utf8mb4_turkish_ci NOT NULL,
  `uyeSoyadi` varchar(300) COLLATE utf8mb4_turkish_ci NOT NULL,
  `mail` varchar(300) COLLATE utf8mb4_turkish_ci NOT NULL,
  `tcno` varchar(300) COLLATE utf8mb4_turkish_ci NOT NULL,
  `dogum_yili` varchar(255) COLLATE utf8mb4_turkish_ci NOT NULL,
  `uyeSifre` varchar(300) COLLATE utf8mb4_turkish_ci NOT NULL,
  `rol` varchar(1) COLLATE utf8mb4_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `uyeler`
--

INSERT INTO `uyeler` (`uyeId`, `uyeAdi`, `uyeSoyadi`, `mail`, `tcno`, `dogum_yili`, `uyeSifre`, `rol`) VALUES
(10, 'furkan', 'furkan', 'a', '12311231231', '1231', '1', 'a'),
(13, 'root', 'admin', 'root', '', '', '1', 'u'),
(14, 'Ahemt', 'Can', 'a@ahmt.com', '1234566325', '1423', '1', 'u'),
(15, 'Mehmet', 'Kaya', 'm@mehmet.com', '14785236965', '2589', '1', 'u'),
(16, 'Yusuf', 'Demir', 'y@yusuf.com', '15963247852', '2589', '1', 'u'),
(17, 'Berke', 'Yol', 'b@Berke.com', '78963254125', '2589', '1', 'u');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `destek_mesaj`
--
ALTER TABLE `destek_mesaj`
  ADD PRIMARY KEY (`mesajId`);

--
-- Tablo için indeksler `gonderi_takip`
--
ALTER TABLE `gonderi_takip`
  ADD PRIMARY KEY (`gonderiId`),
  ADD UNIQUE KEY `gonderen_mail` (`gonderen_mail`);

--
-- Tablo için indeksler `uyeler`
--
ALTER TABLE `uyeler`
  ADD PRIMARY KEY (`uyeId`),
  ADD UNIQUE KEY `tcno` (`tcno`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `destek_mesaj`
--
ALTER TABLE `destek_mesaj`
  MODIFY `mesajId` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `gonderi_takip`
--
ALTER TABLE `gonderi_takip`
  MODIFY `gonderiId` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Tablo için AUTO_INCREMENT değeri `uyeler`
--
ALTER TABLE `uyeler`
  MODIFY `uyeId` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
