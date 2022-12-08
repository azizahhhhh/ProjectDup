-- data pribadi pelanggan
CREATE TABLE data_pribadi_pelanggan (
    id_pelanggan SERIAl,
    username     varchar(30) NOT NULL,
    password     varchar(20) NOT NULL,
    no_ktp       CHAR(16) NOT NULL,
    nama         varchar(50) NOT NULL,
    no_hp        varchar(20) NOT NULL,
    email        varchar(30) NOT NULL
);

ALTER TABLE data_pribadi_pelanggan ADD CONSTRAINT data_pribadi_pelanggan_pk PRIMARY KEY ( id_pelanggan );
select * from data_pribadi_pelanggan;

-- data admin

CREATE TABLE data_admin (
    id_admin SERIAL,
    nama     varchar(50) NOT NULL,
    username varchar(30) NOT NULL,
    password varchar(20) NOT NULL,
    no_hp    varchar(20) NOT NULL
);

ALTER TABLE data_admin ADD CONSTRAINT data_admin_pk PRIMARY KEY ( id_admin );

ALTER TABLE data_admin ADD CONSTRAINT data_admin_no_hp_un UNIQUE ( no_hp );
select * from data_admin

-- data tipe kamar
CREATE TABLE data_kamar (
    id_kamar    SERIAL,
    nama_kamar  varchar(30) NOT NULL,
    harga       varchar(10) NOT NULL
);
ALTER TABLE data_kamar ADD CONSTRAINT data_kamar_pk PRIMARY KEY ( id_kamar );
select * from data_kamar

-- reservasi

CREATE TABLE reservasi (
    id_reservasi                        CHAR(2) NOT NULL,
    jumlah_pemesanan                    INTEGER NOT NULL, 
    id_pelanggan                        INTEGER NOT NULL,
    id_admin                            INTEGER NOT NULL,
    tanggal_reservasi                   DATE NOT NULL
);
ALTER TABLE reservasi ADD CONSTRAINT data_reservasi_pk PRIMARY KEY ( id_reservasi );

ALTER TABLE reservasi
    ADD CONSTRAINT reservasi_data_admin_fk FOREIGN KEY ( id_admin )
        REFERENCES data_admin ( id_admin );

ALTER TABLE reservasi
    ADD CONSTRAINT reservasi_data_pribadi_pelanggan_fk FOREIGN KEY ( id_pelanggan )
        REFERENCES data_pribadi_pelanggan ( id_pelanggan );
		
select * from reservasi

-- detail reservasi

CREATE TABLE detail_reservasi (
    id_detail_reservasi      SERIAL,
    tanggal_check_in         DATE NOT NULL,
    tanggal_check_out        DATE NOT NULL,
    id_reservasi             CHAR(2) NOT NULL,
    id_kamar 				 INTEGER NOT NULL
);

ALTER TABLE detail_reservasi
    ADD CONSTRAINT detail_reservasi_pk PRIMARY KEY ( id_detail_reservasi );

ALTER TABLE detail_reservasi
    ADD CONSTRAINT detail_reservasi_data_kamar_fk FOREIGN KEY ( id_kamar )
        REFERENCES data_kamar ( id_kamar );

ALTER TABLE detail_reservasi
    ADD CONSTRAINT detail_reservasi_reservasi_fk FOREIGN KEY ( id_reservasi )
        REFERENCES reservasi ( id_reservasi );

select * from detail_reservasi