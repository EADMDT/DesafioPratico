CREATE SEQUENCE IF NOT EXISTS hotels_id_seq;

CREATE TABLE IF NOT EXISTS public.hotels
(
    id integer NOT NULL DEFAULT nextval('hotels_id_seq'::regclass),
    name character varying(255) COLLATE pg_catalog."default" NOT NULL,
    adress character varying(255) COLLATE pg_catalog."default" NOT NULL,
    phone character varying(20) COLLATE pg_catalog."default",
    description text COLLATE pg_catalog."default",
    rating integer,
    CONSTRAINT hotels_pkey PRIMARY KEY (id)
)