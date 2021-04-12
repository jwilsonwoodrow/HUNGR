Select yelp_restaurant_id, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number from saved_restaurants sr 
	JOIN user_restaurants ur ON ur.restaurant_id = sr.restaurant_id
	JOIN users u ON u.user_id = ur.user_id
	WHERE u.email = 'admin@gmail.com'