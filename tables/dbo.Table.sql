CREATE TABLE [dbo].[LibraryMember]
(
	[MemberID] INT identity NOT NULL PRIMARY KEY,
	NameFirst varchar(30) not null,
	NameInitial varchar(30) null,
	NameLast varchar(30) not null,
	Username varchar(30) not null,
	Password varchar(30) not null,
	Address varchar(30) not null,
	Street varchar(30) null,
	Town varchar(30) not null,
	County varchar(30) null,
	Country varchar(30) null,
	Postcode varchar(30) not null,
	Classification int not null
)
