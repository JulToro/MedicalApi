CREATE TABLE facilities (
	id SERIAL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	city VARCHAR(100) NOT NULL
);

CREATE TABLE patients(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	age INT NOT NULL
);

CREATE TABLE payers (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    city VARCHAR(100) NOT NULL
);

CREATE TABLE encounters (
    id SERIAL PRIMARY KEY,
    patient_id INT REFERENCES patients(id),
    facility_id INT REFERENCES facilities(id),
    payer_id INT REFERENCES payers(id),
    encounter_date DATE NOT NULL
);

-- Insert data in facilities
INSERT INTO facilities (name, city) VALUES ('Hospital 1', 'Philadelphia');
INSERT INTO facilities (name, city) VALUES ('Clinic 1', 'New York');
INSERT INTO facilities (name, city) VALUES ('Hospital 2', 'Boston');
INSERT INTO facilities (name, city) VALUES ('Clinic 2', 'Newark');
INSERT INTO facilities (name, city) VALUES ('Hospital 3', 'Jersey City');

-- Insert data in patients
INSERT INTO patients (first_name, last_name, age) VALUES ('John', 'Garces', 30);
INSERT INTO patients (first_name, last_name, age) VALUES ('Bruce', 'Wayne', 14);
INSERT INTO patients (first_name, last_name, age) VALUES ('Albert', 'Einstein', 70);
INSERT INTO patients (first_name, last_name, age) VALUES ('Mary', 'Jane', 22);
INSERT INTO patients (first_name, last_name, age) VALUES ('Robert', 'Brown', 45);

-- Insert data in payers
INSERT INTO payers (name, city) VALUES ('Sura', 'Philadelphia');
INSERT INTO payers (name, city) VALUES ('Comeva', 'New York');
INSERT INTO payers (name, city) VALUES ('Humanitas', 'Boston');
INSERT INTO payers (name, city) VALUES ('SaludCoop', 'Newark');
INSERT INTO payers (name, city) VALUES ('Medimas', 'Jersey City');

-- Insert data in encounters
INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (1, 1, 1, '2023-01-01');
INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (1, 2, 2, '2023-02-01');
INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (1, 3, 3, '2023-03-01');

INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (2, 1, 1, '2023-01-10');
INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (2, 2, 2, '2023-02-10');

INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (3, 3, 3, '2023-03-10');
INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (3, 4, 4, '2023-04-10');

INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (4, 4, 4, '2023-05-10');
INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (4, 5, 5, '2023-06-10');
INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (4, 1, 1, '2023-07-10');

INSERT INTO encounters (patient_id, facility_id, payer_id, encounter_date) VALUES (5, 2, 2, '2023-08-10');