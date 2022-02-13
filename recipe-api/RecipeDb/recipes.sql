CREATE TABLE IF NOT EXISTS recipes (
   `id` 								  BIGINT AUTO_INCREMENT
	,`name` 								TEXT
  ,`image` 						    TEXT
	,`created_by` 					BIGINT NOT NULL DEFAULT 1
	,`created_date` 				DATETIME DEFAULT CURRENT_TIMESTAMP
	,`updated_by` 					BIGINT NOT NULL DEFAULT 1
	,`updated_date` 				DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
	,`is_deleted` 					BOOLEAN DEFAULT FALSE
	,PRIMARY KEY (id)
);
