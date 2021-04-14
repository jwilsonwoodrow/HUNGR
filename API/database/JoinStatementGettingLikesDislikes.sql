

Select sr.photo_url, sr.yelp_restaurant_id, sr.restaurant_name, sr.restaurant_address, sr.restaurant_city, sr.restaurant_state, sr.restaurant_zip_code, sr.category, sr.phone_number, rld.num_of_likes, rld.num_of_dislikes
	FROM saved_restaurants sr 
	JOIN restaurant_likes_dislikes rld ON rld.restaurant_id = sr.restaurant_id
	JOIN invite_restaurants ir ON ir.restaurant_id = sr.restaurant_id
	WHERE ir.invite_id = 1;

INSERT INTO restaurant_likes_dislikes (restaurant_id, num_of_likes, num_of_dislikes)
	VALUES(@restId, @num_of_likes, @num_of_dislikes);

	--going to have to do an update statement to update the num_of_likes and num_of_dislikes where restaurant_id = @restId

