CREATE TABLE IF NOT EXISTS ingredients (
     `id` 							BIGINT AUTO_INCREMENT
	,`rating_id` 					BIGINT NOT NULL
	,`comment` 						TEXT
	,`created_by` 					BIGINT NOT NULL DEFAULT 1
	,`created_date` 				DATETIME DEFAULT CURRENT_TIMESTAMP
	,`updated_by` 					BIGINT NOT NULL DEFAULT 1
	,`updated_date` 				DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
	,`is_deleted` 					BOOLEAN DEFAULT FALSE
	,PRIMARY KEY (id)
	,CONSTRAINT fk_recipe_ingredient FOREIGN KEY (recipe_id) REFERENCES recipes(id)
    ,CONSTRAINT fk_raiting_comment FOREIGN KEY (raiting_id) REFERENCES rating(id)
);
