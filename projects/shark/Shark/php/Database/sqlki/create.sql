-- Table: services

-- DROP TABLE services;

CREATE TABLE services
(
  id serial NOT NULL,
  name text,
<<<<<<< HEAD
  surname text,
  email text,
  phone text,
  chosencourse text,
  signature text,
  mailconfirmed boolean,
  CONSTRAINT applicants_pkey PRIMARY KEY (id)
);
=======
  price text,
  CONSTRAINT services_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE services
  OWNER TO postgres;


>>>>>>> 3769671cabb5f7a1f7710e9c6f187da5655eb174

-- DROP TABLE clients;

CREATE TABLE clients
(
  id serial NOT NULL,
  name text,
  address text,
  postalcode text,
  city text,
  nip text,
  CONSTRAINT clients_pkey PRIMARY KEY (id)
);



-- Table: invoices

-- DROP TABLE invoices;

CREATE TABLE invoices
(
  id serial NOT NULL,
  client_id integer,
  "number" text,
  html text,
  CONSTRAINT invoices_pkey PRIMARY KEY (id),
  CONSTRAINT invoices_client_id_fkey FOREIGN KEY (client_id)
      REFERENCES clients (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
);
