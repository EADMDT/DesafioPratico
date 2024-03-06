CREATE SEQUENCE IF NOT EXISTS rooms_id_seq;

CREATE TABLE IF NOT EXISTS public.rooms
(
    id integer NOT NULL DEFAULT nextval('rooms_id_seq'::regclass),
    hotel_id integer NOT NULL,
    room_number character varying(30) COLLATE pg_catalog."default" NOT NULL,
    capacity integer NOT NULL,
    description text COLLATE pg_catalog."default",
    photos character varying(255) COLLATE pg_catalog."default",
    CONSTRAINT room_hotel PRIMARY KEY (id),
    CONSTRAINT rooms_fkey FOREIGN KEY (hotel_id)
        REFERENCES public.hotels (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)