--
-- PostgreSQL database dump
--

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: english; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE english (
    id integer NOT NULL,
    phrase text NOT NULL,
    fk_id_language integer
);


ALTER TABLE public.english OWNER TO postgres;

--
-- Name: frazy; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE frazy (
    id integer NOT NULL,
    fraza text
);


ALTER TABLE public.frazy OWNER TO postgres;

--
-- Name: frazy_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE frazy_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.frazy_id_seq OWNER TO postgres;

--
-- Name: frazy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE frazy_id_seq OWNED BY frazy.id;


--
-- Name: german; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE german (
    id integer NOT NULL,
    phrase text NOT NULL,
    fk_id_language integer
);


ALTER TABLE public.german OWNER TO postgres;

--
-- Name: jezyk; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE jezyk (
    id integer NOT NULL,
    name text
);


ALTER TABLE public.jezyk OWNER TO postgres;

--
-- Name: jezyk_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE jezyk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.jezyk_id_seq OWNER TO postgres;

--
-- Name: jezyk_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE jezyk_id_seq OWNED BY jezyk.id;


--
-- Name: language; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE language (
    id_language integer NOT NULL,
    language text
);


ALTER TABLE public.language OWNER TO postgres;

--
-- Name: languages; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE languages (
    id_languages integer NOT NULL,
    language text NOT NULL
);


ALTER TABLE public.languages OWNER TO postgres;

--
-- Name: polish; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE polish (
    id integer NOT NULL,
    phrase text NOT NULL,
    fk_id_language integer
);


ALTER TABLE public.polish OWNER TO postgres;

--
-- Name: tlumaczenia; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE tlumaczenia (
    id integer NOT NULL,
    fk_id_jezyk integer NOT NULL,
    fk_id_frazy integer NOT NULL,
    tlumaczenie text
);


ALTER TABLE public.tlumaczenia OWNER TO postgres;

--
-- Name: tlumaczenia_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE tlumaczenia_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tlumaczenia_id_seq OWNER TO postgres;

--
-- Name: tlumaczenia_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tlumaczenia_id_seq OWNED BY tlumaczenia.id;


--
-- Name: translation; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE translation (
    id_translation bigint NOT NULL,
    fk_id_language bigint NOT NULL,
    translation_content json
);


ALTER TABLE public.translation OWNER TO postgres;

--
-- Name: translation_fk_id_language_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE translation_fk_id_language_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.translation_fk_id_language_seq OWNER TO postgres;

--
-- Name: translation_fk_id_language_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE translation_fk_id_language_seq OWNED BY translation.fk_id_language;


--
-- Name: translation_id_translation_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE translation_id_translation_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.translation_id_translation_seq OWNER TO postgres;

--
-- Name: translation_id_translation_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE translation_id_translation_seq OWNED BY translation.id_translation;


--
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY frazy ALTER COLUMN id SET DEFAULT nextval('frazy_id_seq'::regclass);


--
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY jezyk ALTER COLUMN id SET DEFAULT nextval('jezyk_id_seq'::regclass);


--
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tlumaczenia ALTER COLUMN id SET DEFAULT nextval('tlumaczenia_id_seq'::regclass);


--
-- Name: id_translation; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY translation ALTER COLUMN id_translation SET DEFAULT nextval('translation_id_translation_seq'::regclass);


--
-- Name: fk_id_language; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY translation ALTER COLUMN fk_id_language SET DEFAULT nextval('translation_fk_id_language_seq'::regclass);


--
-- Name: english_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY english
    ADD CONSTRAINT english_pkey PRIMARY KEY (id);


--
-- Name: frazy_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY frazy
    ADD CONSTRAINT frazy_pkey PRIMARY KEY (id);


--
-- Name: german_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY german
    ADD CONSTRAINT german_pkey PRIMARY KEY (id);


--
-- Name: jezyk_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY jezyk
    ADD CONSTRAINT jezyk_pkey PRIMARY KEY (id);


--
-- Name: language_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY language
    ADD CONSTRAINT language_pkey PRIMARY KEY (id_language);


--
-- Name: languages_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY languages
    ADD CONSTRAINT languages_pkey PRIMARY KEY (id_languages);


--
-- Name: polish_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY polish
    ADD CONSTRAINT polish_pkey PRIMARY KEY (id);


--
-- Name: tlumaczenia_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tlumaczenia
    ADD CONSTRAINT tlumaczenia_pkey PRIMARY KEY (id);


--
-- Name: translation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY translation
    ADD CONSTRAINT translation_pkey PRIMARY KEY (id_translation);


--
-- Name: english_fk_id_language_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY english
    ADD CONSTRAINT english_fk_id_language_fkey FOREIGN KEY (fk_id_language) REFERENCES languages(id_languages);


--
-- Name: german_fk_id_language_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY german
    ADD CONSTRAINT german_fk_id_language_fkey FOREIGN KEY (fk_id_language) REFERENCES languages(id_languages);


--
-- Name: polish_fk_id_language_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY polish
    ADD CONSTRAINT polish_fk_id_language_fkey FOREIGN KEY (fk_id_language) REFERENCES languages(id_languages);


--
-- Name: tlumaczenia_fk_id_frazy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tlumaczenia
    ADD CONSTRAINT tlumaczenia_fk_id_frazy_fkey FOREIGN KEY (fk_id_frazy) REFERENCES frazy(id);


--
-- Name: tlumaczenia_fk_id_jezyk_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tlumaczenia
    ADD CONSTRAINT tlumaczenia_fk_id_jezyk_fkey FOREIGN KEY (fk_id_jezyk) REFERENCES jezyk(id);


--
-- Name: translation_fk_id_language_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY translation
    ADD CONSTRAINT translation_fk_id_language_fkey FOREIGN KEY (fk_id_language) REFERENCES language(id_language);


--
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- PostgreSQL database dump complete
--

