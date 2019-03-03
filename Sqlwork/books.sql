drop database if exists library;
create database library;
use library; -- MySQL

create table Publisher(
publisherId int,
name varchar(64) NOT NULL,
country varchar(64) NOT NULL,
PRIMARY KEY(publisherId)
);

create table books(
bookId int,-- bookId int PRIMARY KEY
title varchar(1024) NOT NULL, -- varchar does't go beyond max# given to it
publishDate date NOT NULL,
publisherId int NOT NULL,
ISBN char(13) NOT NULL,
PRIMARY KEY(bookId),
FOREIGN KEY(publisherId)
REFERENCES Publisher(publisherId)
);

create table bookCopy(
bookId int NOT NULL, -- this foreign key
bookStamp char(14), -- the is the pk
PRIMARY KEY(bookStamp),
FOREIGN KEY(bookId) REFERENCES books(bookId)
);



create table genres (
genreId int,
name varchar(32)NOT NULL UNIQUE,
PRIMARY KEY(genreId)
);

create table bookGenres (
bookId int,
genreId int,
PRIMARY KEY(bookId, genreId),
FOREIGN KEY(bookId) REFERENCES books(bookId),
FOREIGN KEY (genreId) REFERENCES genres(genreId)
);

create table authors(
authorId int,
firstName varchar(256),
lastName varchar(256),
PRIMARY KEY(authorId)
);

create table bookAuthors(
bookId int,
authorId int,
PRIMARY KEY(bookId, authorId),
FOREIGN KEY(bookId) REFERENCES books(bookId),
FOREIGN KEY(authorId) REFERENCES authors(authorId)
);

create table patrons(
patronId int,
firstName varchar(64) NOT NULL,
lastName varchar(64) NOT NULL,
address varchar (128) NOT NULL,
email varchar(64) NOT NULL,
phone varchar(18) NOT NULL,
PRIMARY KEY (patronId)
);

create table checkouts(
bookStamp char(14),
patronId int,
checkoutDate dateTime,
returnDate datEtime DEFAULT NULL,
PRIMARY KEY(bookStamp, patronId, checkoutDate),
FOREIGN KEY(bookStamp) REFERENCES bookCopy(bookStamp),
FOREIGN KEY(patronId) REFERENCES patrons(patronId)
);
