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
CREATE TABLE saved_restaurants (
	restaurant_id int IDENTITY(1,1) NOT NULL,
	photo_url varchar(200) NULL,
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
	user_id int NOT NULL,
	invite_title varchar(200) NOT NULL,
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
CREATE TABLE user_invite (
	user_id int NOT NULL,
	invite_id int NOT NULL,
	CONSTRAINT FK_restaurant_user_id FOREIGN KEY (user_id) references users(user_id),
	CONSTRAINT FK_user_invite_id FOREIGN KEY (invite_id) references invites(invite_id),
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
	VALUES ((select user_id from users where username = 'admin'), 'Birthday','2021-04-25 12:00:00', '2021-04-30 12:00:00'),
	((select user_id from users where username = 'admin'), 'Lunch','2021-04-15 12:00:00', '2021-04-20 12:00:00'),
	((select user_id from users where username = 'user'), 'Anniversary','2021-04-20 12:00:00', '2021-04-25 12:00:00');

INSERT INTO saved_restaurants(yelp_restaurant_id, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number) 
	VALUES ('QBNbyEzqc7VnCMo5JTos4w', 'BurgerIM', '11419 Euclid Ave', 'Cleveland', 'OH', '44106', 'Burgers', '(216) 795-5999'),
	('6qxE-dfIP73khQHu4ZCZow', 'Table Six Kitchen + Bar', '6113 Whipple Ave NW', 'North Canton', 'OH', '44720', 'American (New)', '(330) 305-1666'),
	('gbX5yBcJWYVoALKtsIoteg', 'Sylvesters North End Grille', '4305 Portage St NW', 'North Canton', 'OH', '44720', 'Italian', '(330) 497-1533');

INSERT INTO invite_restaurants(invite_id, restaurant_id) 
	VALUES ((select invite_id from invites where user_id = 2 and invite_title = 'Birthday'), (select restaurant_id from saved_restaurants where restaurant_name = 'BurgerIM')),
	((select invite_id from invites where user_id = 2 and invite_title = 'Birthday'), (select restaurant_id from saved_restaurants where restaurant_name = 'Table Six Kitchen + Bar')),
	((select invite_id from invites where user_id = 2 and invite_title = 'Lunch'), (select restaurant_id from saved_restaurants where restaurant_name = 'Table Six Kitchen + Bar')),
	((select invite_id from invites where user_id = 1 and invite_title = 'Anniversary'), (select restaurant_id from saved_restaurants where restaurant_name = 'Sylvesters North End Grille'));

INSERT INTO restaurant_likes_dislikes(restaurant_id, num_of_likes, num_of_dislikes) 
	VALUES ((select restaurant_id from saved_restaurants where restaurant_name = 'BurgerIM'), 3, 0);

INSERT INTO user_invite(user_id, invite_id) 
	VALUES ((select user_id from users where email = 'admin@gmail.com'), (select invite_id from invites where invite_title = 'Birthday' and user_id = (select user_id from users where email = 'admin@gmail.com'))),
	((select user_id from users where email = 'admin@gmail.com'), (select invite_id from invites where invite_title = 'Lunch' and user_id = (select user_id from users where email = 'admin@gmail.com'))),
	((select user_id from users where email = 'user@gmail.com'), (select invite_id from invites where invite_title = 'Anniversary' and user_id = (select user_id from users where email = 'user@gmail.com')));	

GO


select * from invites