USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	email varchar(100) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE attendees (
	attendee_id int IDENTITY(1,1) NOT NULL,
	attendee_name varchar(200) NOT NULL,
	attendee_email varchar(200) NOT NULL,
	CONSTRAINT PK_attendee_id PRIMARY KEY (attendee_id)
)
CREATE TABLE saved_restaurants (
	restaurant_id int IDENTITY(1,1) NOT NULL,
	yelp_restaurant_id varchar(200) NOT NULL,
	restaurant_name varchar(200) NOT NULL,
	restaurant_address varchar(200) NOT NULL,
	restaurant_city varchar(200) NOT NULL,
	restaurant_state varchar(200) NOT NULL,
	restaurant_zip_code varchar(200) NOT NULL,
	category varchar(200) NULL,
	phone_number varchar(200) NULL,
	CONSTRAINT PK_saved_restaurant PRIMARY KEY (restaurant_id),
)
CREATE TABLE invites (
	invite_id int IDENTITY(1,1) NOT NULL,
	invite_title varchar(200) NOT NULL,
	user_id int NOT NULL,
	expiry_date datetime NOT NULL,
	event_date datetime NOT NULL,
	CONSTRAINT PK_invites PRIMARY KEY (invite_id),
	CONSTRAINT FK_invite_user FOREIGN KEY (user_id) references users(user_id)
)
CREATE TABLE invite_restaurants (
	invite_id int NOT NULL,
	restaurant_id int NOT NULL,
	CONSTRAINT FK_invite_restaurant_id FOREIGN KEY (invite_id) references invites(invite_id),
	CONSTRAINT FK_invite_restaurant FOREIGN KEY (restaurant_id) references saved_restaurants(restaurant_id),
)
CREATE TABLE invite_attendees (
	attendee_id int NOT NULL,
	invite_id int NOT NULL,
	CONSTRAINT FK_invite_attendee_id FOREIGN KEY (invite_id) references invites(invite_id),
	CONSTRAINT FK_invite_attendee FOREIGN KEY (attendee_id) references attendees(attendee_id),
)
CREATE TABLE user_restaurants (
	user_id int NOT NULL,
	restaurant_id int NOT NULL,
	CONSTRAINT FK_restaurant_user_id FOREIGN KEY (user_id) references users(user_id),
	CONSTRAINT FK_user_restaurant_id FOREIGN KEY (restaurant_id) references saved_restaurants(restaurant_id),
)
CREATE TABLE restaurant_likes_dislikes (
	restaurant_id int NOT NULL,
	num_of_likes int NULL,
	num_of_dislikes int NULL,
	CONSTRAINT FK_restaurant_like_dislike_id FOREIGN KEY (restaurant_id) references saved_restaurants(restaurant_id),
)

--populate default data
INSERT INTO users (email, username, password_hash, salt, user_role) VALUES ('user@gmail.com','user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, username, password_hash, salt, user_role) VALUES ('admin@gmail.com', 'admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO invites(user_id, invite_title, expiry_date, event_date)
	VALUES ((select user_id from users where username = 'admin'), 'Birthday','2021-04-25 12:00:00', '2021-04-30 12:00:00');

INSERT INTO attendees(attendee_name, attendee_email) 
	VALUES ('Lucinda', 'lucinda@gmail.com'),
	('Jason', 'jason@gmail.com'),
	('Mike', 'mike@gmail.com');

INSERT INTO saved_restaurants(yelp_restaurant_id, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number) 
	VALUES ('QBNbyEzqc7VnCMo5JTos4w', 'BurgerIM', '11419 Euclid Ave', 'Cleveland', 'OH', '44106', 'Burgers', '(216) 795-5999'),
	('6qxE-dfIP73khQHu4ZCZow', 'Table Six Kitchen + Bar', '6113 Whipple Ave NW', 'North Canton', 'OH', '44720', 'American (New)', '(330) 305-1666'),
	('gbX5yBcJWYVoALKtsIoteg', 'Sylvesters North End Grille', '4305 Portage St NW', 'North Canton', 'OH', '44720', 'Italian', '(330) 497-1533');

INSERT INTO invite_restaurants(invite_id, restaurant_id) 
	VALUES ((select invite_id from invites where user_id = 2 and invite_title = 'Birthday'), (select restaurant_id from saved_restaurants where restaurant_name = 'BurgerIM'));

INSERT INTO invite_attendees(attendee_id, invite_id) 
	VALUES ((select attendee_id from attendees where attendee_email ='lucinda@gmail.com'), (select invite_id from invites where user_id = 2 and invite_title = 'Birthday'));

INSERT INTO restaurant_likes_dislikes(restaurant_id, num_of_likes, num_of_dislikes) 
	VALUES ((select restaurant_id from saved_restaurants where restaurant_name = 'BurgerIM'), 3, 0);

INSERT INTO user_restaurants(user_id, restaurant_id) 
	VALUES ((select user_id from users where email = 'admin@gmail.com'), (select restaurant_id from saved_restaurants where restaurant_name = 'BurgerIM')),
	((select user_id from users where email = 'admin@gmail.com'), (select restaurant_id from saved_restaurants where restaurant_name = 'Table Six Kitchen + Bar')),
	((select user_id from users where email = 'user@gmail.com'), (select restaurant_id from saved_restaurants where restaurant_name = 'Sylvesters North End Grille'));	

GO