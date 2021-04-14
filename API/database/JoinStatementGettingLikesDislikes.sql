

Select invites.invite_id, invites.invite_title, invites.expiry_date, invites.event_date, saved_restaurants.restaurant_id, saved_restaurants.yelp_restaurant_id, saved_restaurants.restaurant_name, saved_restaurants.restaurant_address, saved_restaurants.restaurant_city,
saved_restaurants.restaurant_state, saved_restaurants.restaurant_zip_code, saved_restaurants.category, saved_restaurants.phone_number, restaurant_likes_dislikes.num_of_dislikes, restaurant_likes_dislikes.num_of_likes
FROM saved_restaurants
JOIN invite_restaurants ON invite_restaurants.restaurant_id = saved_restaurants.restaurant_id
JOIN restaurant_likes_dislikes ON restaurant_likes_dislikes.restaurant_id = invite_restaurants.restaurant_id
JOIN invites ON invites.invite_id = invite_restaurants.invite_id
where invites.invite_id = 1

INSERT INTO restaurant_likes_dislikes (restaurant_id, num_of_likes, num_of_dislikes)
	VALUES(@restId, @num_of_likes, @num_of_dislikes);

UPDATE restaurant_likes_dislikes
SET num_of_dislikes = @numOfDislikes,
num_of_likes = @numOfLikes
WHERE restaurant_id = @restId

	--going to have to do an update statement to update the num_of_likes and num_of_dislikes where restaurant_id = @restId

