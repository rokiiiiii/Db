-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3307
-- Время создания: Май 20 2022 г., 11:38
-- Версия сервера: 10.3.16-MariaDB
-- Версия PHP: 7.3.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `apteka`
--

-- --------------------------------------------------------

--
-- Структура таблицы `lekarstv`
--

CREATE TABLE `lekarstv` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `proiz` varchar(50) NOT NULL,
  `veshestvo` varchar(50) NOT NULL,
  `doza` int(11) NOT NULL,
  `srok` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `fotoname` varchar(50) NOT NULL,
  `foto` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `lekarstv`
--

INSERT INTO `lekarstv` (`id`, `name`, `proiz`, `veshestvo`, `doza`, `srok`, `price`, `fotoname`, `foto`) VALUES
(1, 'Aspirin', 'valera', 'pirin', 2, 12, 5, 'aspirin.jpg', 'C:\\Users\\1194943.MCB\\Downloads\\aspirin.jpg'),
(2, '123', '123', '13', 123, 123, 123, '???????.png', 'C:\\Users\\1194943.MCB\\Downloads\\???????.png'),
(3, '123', '123', '123', 123, 123, 123, '2.png', 'C:\\Users\\1194943.MCB\\Downloads\\2.png'),
(4, '?????', '???', '??????', 3, 2, 5, '2.jpg', 'C:\\Users\\1194943.MCB\\Downloads\\2.jpg');

-- --------------------------------------------------------

--
-- Структура таблицы `nal`
--

CREATE TABLE `nal` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `CountSklad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `nal`
--

INSERT INTO `nal` (`id`, `name`, `CountSklad`) VALUES
(1, 'Aspirin', 12),
(2, 'vv', 12),
(3, 'vvv', 12),
(4, '123', 123),
(5, 'vvvv', 12);

-- --------------------------------------------------------

--
-- Структура таблицы `prodaga`
--

CREATE TABLE `prodaga` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `KolProdag` int(11) NOT NULL,
  `DateProdag` varchar(50) NOT NULL,
  `skidka` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `prodaga`
--

INSERT INTO `prodaga` (`id`, `name`, `KolProdag`, `DateProdag`, `skidka`) VALUES
(1, 'Aspirin', 1, '14102022', 0.5),
(2, 'ygol', 22, '12022002', 0.3);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `lekarstv`
--
ALTER TABLE `lekarstv`
  ADD UNIQUE KEY `id` (`id`);

--
-- Индексы таблицы `nal`
--
ALTER TABLE `nal`
  ADD UNIQUE KEY `шв` (`id`);

--
-- Индексы таблицы `prodaga`
--
ALTER TABLE `prodaga`
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `lekarstv`
--
ALTER TABLE `lekarstv`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `nal`
--
ALTER TABLE `nal`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `prodaga`
--
ALTER TABLE `prodaga`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
