	CREATE TABLE IF NOT EXISTS `analytics` (
		pid VARCHAR(20) NOT NULL,
		param JSON,
		PRIMARY KEY (pid)
	);
	CREATE TABLE IF NOT EXISTS `player_info` (
		id BIGINT UNSIGNED NOT NULL,
		username VARCHAR(12) NOT NULL,
		password VARCHAR(10) NOT NULL,
		migrate_password VARCHAR(12) NOT NULL,
		user_password TEXT NOT NULL,
		player_key VARCHAR(32) NOT NULL,
		last_login BIGINT NOT NULL,
		language INTEGER NOT NULL,
		characters JSON,
		chao JSON,
		suspended_until BIGINT NOT NULL,
		suspend_reason INTEGER NOT NULL,
		last_login_device TEXT NOT NULL,
		last_login_platform INTEGER NOT NULL,
		last_login_versionid INTEGER NOT NULL,
		PRIMARY KEY (id)
	);
	CREATE TABLE IF NOT EXISTS `player_states` (
		id BIGINT UNSIGNED NOT NULL,
		items JSON NOT NULL,
		equipped_items JSON NOT NULL,
		mainchara_id TEXT NOT NULL,
		subchara_id TEXT NOT NULL,
		mainchao_id TEXT NOT NULL,
		subchao_id TEXT NOT NULL,
		num_rings INTEGER NOT NULL,
		num_buy_rings INTEGER NOT NULL,
		num_red_rings INTEGER NOT NULL,
		num_buy_red_rings INTEGER NOT NULL,
		energy INTEGER NOT NULL,
		energy_buy INTEGER NOT NULL,
		energy_renews_at BIGINT NOT NULL,
		num_messages INTEGER NOT NULL,
		ranking_league INTEGER NOT NULL,
		quick_ranking_league INTEGER NOT NULL,
		num_roulette_ticket INTEGER NOT NULL,
		num_chao_roulette_ticket INTEGER NOT NULL,
		chao_eggs INTEGER NOT NULL,
		high_score BIGINT NOT NULL,
		quick_high_score BIGINT NOT NULL,
		total_distance BIGINT NOT NULL,
		best_distance BIGINT NOT NULL,
		daily_mission_id INTEGER UNSIGNED NOT NULL,
		daily_mission_end_time BIGINT NOT NULL,
		daily_challenge_value INTEGER,
		daily_challenge_complete TINYINT UNSIGNED NOT NULL,
		num_daily_chal_cont INTEGER NOT NULL,
		num_plays INTEGER NOT NULL,
		num_animals INTEGER NOT NULL,
		rank_num INTEGER UNSIGNED NOT NULL,
		dm_cat INTEGER NOT NULL,
		dm_set INTEGER NOT NULL,
		dm_pos INTEGER NOT NULL,
		dm_nextcont INTEGER NOT NULL,
		league_high_score BIGINT NOT NULL,
		quick_league_high_score BIGINT NOT NULL,
		league_start_time BIGINT NOT NULL,
		league_reset_time BIGINT NOT NULL,
		ranking_league_group INTEGER NOT NULL,
		quick_ranking_league_group INTEGER NOT NULL,
		total_score BIGINT NOT NULL,
		quick_total_score BIGINT NOT NULL,
		best_total_score BIGINT NOT NULL,
		best_quick_total_score BIGINT NOT NULL,
		PRIMARY KEY (id)
	);
	CREATE TABLE IF NOT EXISTS `player_mileage` (
		id BIGINT UNSIGNED NOT NULL,
		map_distance INTEGER,
		num_boss_attack INTEGER,
		stage_distance INTEGER,
		stage_max_score INTEGER,
		episode INTEGER,
		chapter INTEGER,
		point INTEGER,
		stage_total_score BIGINT,
		chapter_start_time BIGINT NOT NULL,
		PRIMARY KEY (id)
	);
	CREATE TABLE IF NOT EXISTS `player_user_results` (
		id BIGINT UNSIGNED NOT NULL,
		high_total_score INTEGER,
		high_quick_total_score INTEGER,
		total_rings INTEGER,
		total_red_rings INTEGER,
		chao_roulette_spin_count INTEGER,
		roulette_spin_count INTEGER,
		num_jackpots INTEGER,
		best_jackpot INTEGER,
		support INTEGER,
		PRIMARY KEY (id)
	);
	CREATE TABLE IF NOT EXISTS `player_item_roulette_data` (
		id BIGINT UNSIGNED NOT NULL,
		login_roulette_id INTEGER,
		roulette_period_end BIGINT NOT NULL,
		roulette_count_in_period INTEGER,
		got_jackpot_this_period INTEGER,
		PRIMARY KEY (id)
	);
	CREATE TABLE IF NOT EXISTS `player_login_bonus_states` (
		id BIGINT UNSIGNED NOT NULL,
		current_start_dash_bonus_day INTEGER,
		current_login_bonus_day INTEGER,
		last_login_bonus_time BIGINT NOT NULL,
		next_login_bonus_time BIGINT NOT NULL,
		login_bonus_start_time BIGINT NOT NULL,
		login_bonus_end_time BIGINT NOT NULL,
		PRIMARY KEY (id)
	);
	CREATE TABLE IF NOT EXISTS `player_operator_messages` (
		id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
		userid BIGINT UNSIGNED NOT NULL,
		contents TEXT,
		item JSON,
		expire_time BIGINT NOT NULL,
		PRIMARY KEY (id)
	);
	CREATE TABLE IF NOT EXISTS `ranking_league_data` (
		league_id INT UNSIGNED NOT NULL,
		group_id INT UNSIGNED NOT NULL,
		start_time BIGINT NOT NULL,
		reset_time BIGINT NOT NULL,
		league_player_count INTEGER,
		group_player_count INTEGER,
		PRIMARY KEY (league_id, group_id)
	);
	CREATE TABLE IF NOT EXISTS `session_ids` (
		sid VARCHAR(48) NOT NULL,
		uid BIGINT UNSIGNED NOT NULL,
		assigned_at_time BIGINT NOT NULL,
		PRIMARY KEY (sid)
	);
	CREATE TABLE IF NOT EXISTS `player_operator_infos` (
		uid BIGINT UNSIGNED NOT NULL,
		id INTEGER NOT NULL,
		param TEXT,
		PRIMARY KEY (uid, id)
	);
	CREATE TABLE IF NOT EXISTS `player_event_states` (
		uid BIGINT UNSIGNED NOT NULL,
		param INTEGER NOT NULL,
		PRIMARY KEY (uid)
	);
	CREATE TABLE IF NOT EXISTS `game_results` (
		gameid BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
		uid BIGINT UNSIGNED NOT NULL,
		score BIGINT NOT NULL,
		rings INTEGER NOT NULL,
		failure_rings INTEGER NOT NULL,
		red_rings INTEGER NOT NULL,
		distance BIGINT NOT NULL,
		daily_challenge_value INTEGER NOT NULL,
		daily_challenge_complete TINYINT NOT NULL,
		animals INTEGER NOT NULL,
		max_combo INTEGER NOT NULL,
		closed TINYINT NOT NULL,
		boss_destroyed TINYINT NOT NULL,
		chapter_clear TINYINT NOT NULL,
		get_chao_egg TINYINT NOT NULL,
		boss_hits INTEGER NOT NULL,
		reach_point INTEGER NOT NULL,
		event_id BIGINT,
		event_value INTEGER,
		cheat_result VARCHAR(8) NOT NULL,
		PRIMARY KEY (gameid)
	);
	CREATE TABLE IF NOT EXISTS `quick_game_results` (
		gameid BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
		uid BIGINT UNSIGNED NOT NULL,
		score BIGINT NOT NULL,
		rings INTEGER NOT NULL,
		failure_rings INTEGER NOT NULL,
		red_rings INTEGER NOT NULL,
		distance BIGINT NOT NULL,
		daily_challenge_value INTEGER NOT NULL,
		daily_challenge_complete TINYINT NOT NULL,
		animals INTEGER NOT NULL,
		max_combo INTEGER NOT NULL,
		closed TINYINT NOT NULL,
		cheat_result VARCHAR(8) NOT NULL,
		PRIMARY KEY (gameid)
	);
	CREATE TABLE IF NOT EXISTS `player_roulette_options` (
		id BIGINT UNSIGNED NOT NULL,
		items JSON,
		item_count JSON,
		item_weight JSON,
		item_won INTEGER,
		next_free_spin BIGINT NOT NULL,
		spin_id BIGINT,
		spin_cost INTEGER,
		roulette_rank INTEGER,
		num_roulette_token INTEGER,
		num_jackpot_ring INTEGER,
		num_remaining_roulette INTEGER,
		item_list JSON,
		PRIMARY KEY (id)
	);
