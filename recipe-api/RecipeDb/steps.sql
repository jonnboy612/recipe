CREATE TABLE IF NOT EXISTS steps (
   `id` 							BIGINT AUTO_INCREMENT
	,`recipe_id` 					BIGINT NOT NULL
	,`order` 						INT
	,`description` 					TEXT
	,`created_by` 					BIGINT NOT NULL DEFAULT 1
	,`created_date` 				DATETIME DEFAULT CURRENT_TIMESTAMP
	,`updated_by` 					BIGINT NOT NULL DEFAULT 1
	,`updated_date` 				DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
	,`is_deleted` 					BOOLEAN DEFAULT FALSE
	,PRIMARY KEY (id)
	,CONSTRAINT fk_recipe_step FOREIGN KEY (recipe_id) REFERENCES recipes(id)
);
