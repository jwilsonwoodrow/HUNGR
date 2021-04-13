Select i.invite_title, sr.yelp_restaurant_id, sr.restaurant_name, sr.restaurant_address, sr.restaurant_city, sr.restaurant_state, sr.restaurant_zip_code, sr.category, sr.phone_number
	FROM saved_restaurants sr 
	JOIN invite_restaurants ir ON ir.restaurant_id = sr.restaurant_id
	JOIN invites i ON i.invite_id = ir.invite_id
	JOIN user_invite ur ON ur.invite_id = ir.invite_id
	where ur.user_id = 2

Select sr.yelp_restaurant_id, sr.restaurant_name, sr.restaurant_address, sr.restaurant_city, sr.restaurant_state, sr.restaurant_zip_code, sr.category, sr.phone_number
	FROM saved_restaurants sr 
	JOIN invite_restaurants ir ON ir.restaurant_id = sr.restaurant_id
	JOIN invites i ON i.invite_id = ir.invite_id
	where i.invite_id = 1

Select i.invite_id, i.invite_title, i.expiry_date, i.event_date
	FROM invites i
	JOIN user_invite ur ON ur.invite_id = i.invite_id
	where ur.user_id = 2