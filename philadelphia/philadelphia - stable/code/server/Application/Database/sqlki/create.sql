
-- zmiana mailconfimred z text na boolean
alter table applicants alter column mailconfirmed type boolean
using case when mailconfirmed='false' then FALSE else true end;

-- Table: applicants
DROP TABLE applicants;

CREATE TABLE applicants
(
  id serial NOT NULL,
  name text,
  surname text,
  email text,
  phone text,
  chosencourse text,
  signature text,
  mailconfirmed text,
  CONSTRAINT applicants_pkey PRIMARY KEY (id)
)