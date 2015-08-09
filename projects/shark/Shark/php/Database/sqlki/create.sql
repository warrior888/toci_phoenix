
CREATE TABLE clients
(
  id serial NOT NULL,
  name text,
  address text,
  postalcode text,
  city text,
  nip text,
  CONSTRAINT clients_pkey PRIMARY KEY (id)
)

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
)

CREATE TABLE services
(
  id serial NOT NULL,
  name text,
  price text,
  CONSTRAINT services_pkey PRIMARY KEY (id)
)