<?php

    $type = $_POST[ "type" ];
    $val = $_POST[ "product" ];

    if( $type == "product" ) {

        if ( $val == "notebooks" ) $prd = get_notebooks_list();
        if ( $val == "phones" ) $prd = get_smartphones_list();
        if ( $val == "tablets" ) $prd = get_tablets_list();

    }
    elseif ( $type == "filter" ) {

        $price_min = ( int )$_POST[ "price_min" ];
        $price_max = ( int )$_POST[ "price_max" ];

        if ( $val == "notebooks" ) $prd = filter_notebooks_list( $price_min, $price_max );
        if ( $val == "phones" ) $prd = filter_smartphones_list( $price_min, $price_max );
        if ( $val == "tablets" ) $prd = filter_tablets_list( $price_min, $price_max );

    }
    elseif ( $type == "search" ) {

        $text_search = $_POST[ "value" ];
        $prd = search_products( $text_search );

    }

    echo '<span class="prod_head">'.$val.'</span>';

    foreach ( $prd as $value ) {

        echo '
               <div class="product">
                        <span class="prod_name">' . $value["name"] . '</span>
                        <div class="prod_photo"><img src="' . $value["img"] . '" alt="" width="150" height="160"></div>';

        if ($value["promo_price"] < $value["price"]) {
            echo '
                        <span class="prod_prom_price">Акция: ' . number_format($value["promo_price"], 0, "", " ") . '</span>
                        <span class="prod_price">Цена: ' . number_format($value["price"], 0, "", " ") . '</span>
                        <span class="prod_desc">' . $value["description"] . '</span>
                      </div>';
        } else {
            echo '
                        <span class="prod_price">Цена: ' . number_format($value["price"], 0, "", " ") . '</span>
                        <span class="prod_desc">' . $value["description"] . '</span>
                      </div>';
        }
    }

    function search_products( $text_search ) {

        $notebooks = get_notebooks_list();
        $phones = get_smartphones_list();
        $tablets = get_tablets_list();

        $array = array();

        foreach ( $notebooks as $value ) {
            $pos = stristr( $value[ "name" ], $text_search );
            if( $pos != false ) $array[] = $value;
        }

        foreach ( $phones as $value ) {
            $pos = stristr( $value[ "name" ], $text_search );
            if( $pos != false ) $array[] = $value;
        }

        foreach ( $tablets as $value ) {
            $pos = stristr( $value[ "name" ], $text_search );
            if( $pos != false ) $array[] = $value;
        }

        return $array;
    }

    function filter_notebooks_list( $price_min, $price_max ) {

        $tmp = get_notebooks_list();
        $array = array();

        foreach ( $tmp as $value ) {
            if( $value[ "price" ] >= $price_min && $value[ "price" ] <= $price_max )
                $array[] = $value;
        }

        return $array;

    }

    function filter_tablets_list( $price_min, $price_max ) {

        $tmp = get_tablets_list();
        $array = array();

        foreach ( $tmp as $value ) {
            if( $value[ "price" ] >= $price_min && $value[ "price" ] <= $price_max ) {
                $array[] = $value;
            }
        }

        return $array;

    }

    function filter_smartphones_list( $price_min, $price_max ) {

        $tmp = get_smartphones_list();
        $array = array();

        foreach ( $tmp as $value ) {
            if( $value[ "price" ] >= $price_min && $value[ "price" ] <= $price_max )
                $array[] = $value;
        }

        return $array;

    }

    function get_notebooks_list() {

        $array[] = array(
            "name" => "Acer Swift 5 SF514-51-7419 (NX.GLDEU.014) Obsidian Black",
            "description" => "Экран 14\" IPS (1920x1080) Full HD, глянцевый / Intel Core i7-7500U (2.7 - 3.5 ГГц) / RAM 8 ГБ / SSD 256 ГБ / Intel HD Graphics 620 / без ОД / Wi-Fi / Bluetooth 4.0 / веб-камера / Windows 10 Home 64bit / 1.3 кг / черный",
            "price" => 32999,
            "promo_price" => 25999,
            "img" => "\img\_notebooks\acer_nx_gldeu_013_5a379495c8e26_images_2425951377.jpg"
        );
        $array[] = array(
            "name" => "Lenovo IdeaPad 320-15IKB (80XL02RJRA) Onyx Black",
            "description" => "Экран 15.6\" (1920x1080) Full HD, матовый / Intel Core i5-7200U (2.5 - 3.1 ГГц) / RAM 8 ГБ / SSD 256 ГБ / nVidia GeForce GT 940MX, 2 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / DOS / 2.2 кг / черный",
            "price" => 17999,
            "promo_price" => 16699,
            "img" => "\img\_notebooks\_lenovo_80xl02r5ra_596de73466559_images_2093039648.jpg"
        );
        $array[] = array(
            "name" => "ASUS VivoBook 15 RZ542UF-DM208 (90RZ0IJ2-M04000) Dark Grey",
            "description" => "Экран 15.6\" (1920x1080) Full HD, матовый / Intel Core i5-8250U (1.6 - 3.4 ГГц) / RAM 8 ГБ / SSD 256 ГБ / nVidia GeForce MX130, 2 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / Endless OS / 2.3 кг / темно-серый",
            "price" => 20799,
            "promo_price" => 18599,
            "img" => "\img\_notebooks\_asus_x542uf_dm208_5bbb129cc7a7f_images_7885533891.jpg"
        );
        $array[] = array(
            "name" => "HP ProBook 450 G5 (4QW12ES)",
            "description" => "Экран 15.6\" (1920х1080) Full HD, матовый / Intel Core i3-8130U (2.2 - 3.4 ГГц) / RAM 8 ГБ / SSD 256 ГБ / nVidia GeForce 930MX, 2 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / DOS / 2.1 кг / серебристый",
            "price" => 21799,
            "promo_price" => 17299,
            "img" => "\img\_notebooks\_hp_1lu50av_v3_5b56fdd4b4448_images_6074581424.jpg"
        );
        $array[] = array(
            "name" => "Dell Inspiron 5379 (53i78S2IHD-WFG) Gray",
            "description" => "Экран 13.3\" IPS (1920x1080) Full HD, Multi-touch, глянцевый / Intel Core i7-8550U (1.8 - 4.0 ГГц) / RAM 8 ГБ / SSD 256 ГБ / Intel UHD 620 / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 10 Home / 1.62 кг / серый",
            "price" => 32499,
            "promo_price" => 27777,
            "img" => "\img\_notebooks\_dell_i1378s2niw_8fg_5aad694edf65d_images_3591494015.jpg"
        );
        $array[] = array(
            "name" => "ASUS VivoBook Pro 17 N705UD-GC094 Dark Grey",
            "description" => "Экран 17.3\" (1920x1080) Full HD, матовый / Intel Core i5-8250U (1.6 - 3.4 ГГц) / RAM 12 ГБ / HDD 1 ТБ + SSD 128 ГБ / nVidia GeForce GTX 1050, 4 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / Endless OS / 2.2 кг / серый металик / сумка + мышь",
            "price" => 30599,
            "promo_price" => 28399,
            "img" => "\img\_notebooks\_asus_n705ud_gc094_images_2313809217.jpg"
        );
        $array[] = array(
            "name" => "Dell Inspiron 3576 (35Fi58S2R5M-WBK) Black",
            "description" => "Экран 15.6\" (1920x1080) Full HD, глянцевый с антибликовым покрытием / Intel Core i5-8250U (1.6 - 3.4 ГГц) / RAM 8 ГБ / SSD 256 ГБ / AMD Radeon 520, 2 ГБ / DVD+/-RW / LAN / Wi-Fi / Bluetooth / веб-камера / Windows 10 Home / 2.25 кг / черный",
            "price" => 21299,
            "promo_price" => 20199,
            "img" => "\img\_notebooks\_dell_35fi58h1r5m_wbk_5ad0b397bb879_images_4089541640.jpg"
        );
        $array[] = array(
            "name" => "MSI GT75-8RF Titan (GT758RF-239UA)",
            "description" => "Экран 17.3\" IPS (3840x2160) Ultra HD 4K, матовый / Intel Core i9-8950HK (2.9 - 4.8 ГГц) / RAM 32 ГБ / HDD 1 ТБ + SSD 512 ГБ / nVidia GeForce GTX 1070, 8 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / Windows 10 / 4.56 кг / черный",
            "price" => 171799,
            "promo_price" => 171799,
            "img" => "\img\_notebooks\_msi_gt758rf_239ua_images_4670078504.jpg"
        );
        $array[] = array(
            "name" => "Apple A1466 MacBook Air 13\" (MQD32)",
            "description" => "Экран 13.3\" (1440x900) WXGA+ LED, глянцевый / Intel Core i5 (1.8 - 2.9 ГГц) / RAM 8 ГБ / SSD 128 ГБ / Intel HD Graphics 6000 / без ОД / Wi-Fi / Bluetooth / веб-камера / macOS Sierra / 1.35 кг",
            "price" => 26789,
            "promo_price" => 23829,
            "img" => "\img\_notebooks\_apple_mqd32ua_a_5aaa639e04541_images_3553516191.jpg"
        );
        $array[] = array(
            "name" => "Lenovo Legion Y530-15ICH (81LB009HRA) Black",
            "description" => "Экран 15.6\" IPS (1920x1080) Full HD, матовый / Intel Core i7-8750H (2.2 - 4.1 ГГц) / RAM 16 ГБ / HDD 1 ТБ + SSD 128 ГБ / nVidia GeForce GTX 1060, 6 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / DOS / 2.3 кг / черный",
            "price" => 45988,
            "promo_price" => 42999,
            "img" => "\img\_notebooks\_lenovo_81lb009hra_images_9180755281.jpg"
        );
        $array[] = array(
            "name" => "HP 250 G6 (4LT15EA) Dark Ash",
            "description" => "Экран 15.6” (1920x1080) Full HD, матовый / Intel Core i3-7020U (2.3 ГГц) / RAM 8 ГБ / SSD 256 ГБ / AMD Radeon 520, 2 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / DOS / 1.86 кг / черный",
            "price" => 14849,
            "promo_price" => 14200,
            "img" => "\img\_notebooks\_hp_4qw21es_5ba3be64cd0a0_images_7527064104.jpg"
        );
        $array[] = array(
            "name" => "Dell Inspiron G3 17 3779 (IG317FI58H1S1DTiL-8BK) Black",
            "description" => "Экран 17.3\" IPS (1920x1080) Full HD, глянцевый с антибликовым покрытием / Intel Core i5-8300H (2.3 - 4.0 ГГц) / RAM 8 ГБ / HDD 1 ТБ + SSD 128 ГБ / nVidia GeForce GTX 1050 Ti, 4 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / Linux / 3.27 кг / черный",
            "price" => 29999,
            "promo_price" => 28999,
            "img" => "\img\_notebooks\_dell_37g3i58s1h1g15_lbk_5bd843a4d4cc8_images_8345836030.jpg"
        );
        $array[] = array(
            "name" => "Acer Predator Triton 700 PT715-51 Obsidian Black",
            "description" => "Экран 15.6\" IPS (1920x1080) Full HD, матовый / Intel Core i7-7700HQ (2.8 - 3.8 ГГц) / RAM 32 ГБ / SSD 1 ТБ RAID (2x512 ГБ) / NVIDIA GeForce GTX 1080, 8 ГБ / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 10 Home / 2.45 кг / черный",
            "price" => 118199,
            "promo_price" => 110999,
            "img" => "\img\_notebooks\_acer_nh_q2keu_007_59f1b5752cc02_images_2294079329.jpg"
        );
        $array[] = array(
            "name" => "Acer Nitro 5 AN515-52 (NH.Q3XEU.021) Shale Black",
            "description" => "Экран 15.6” IPS (1920x1080) Full HD, матовый / Intel Core i5-8300H (2.3 - 4.0 ГГц) / RAM 8 ГБ / HDD 1 ТБ + SSD 256 ГБ / nVidia GeForce GTX 1060, 6 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / Linux / 2.7 кг / черный",
            "price" => 35099,
            "promo_price" => 33499,
            "img" => "\img\_notebooks\_acer_nh_q3xeu_011_5ba965adceae5_images_7621922292.jpg"
        );
        $array[] = array(
            "name" => "ASUS ZenBook UX430UN-GV027T (90NB0GH5-M00570) Blue",
            "description" => "Экран 14.0\" (1920x1080) Full HD, матовый / Intel Core i7-8550U (1.8 - 4.0 ГГц) / RAM 16 ГБ / SSD 512 ГБ / nVidia GeForce MX150, 2 ГБ / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 10 / 1.3 кг / синий / чехол + мышь",
            "price" => 39591,
            "promo_price" => 37999,
            "img" => "\img\_notebooks\_asus_ux430un_gv027t_images_2313834273.jpg"
        );
        $array[] = array(
            "name" => "Xiaomi Mi Gaming Laptop 15.6\" (JYU4084CN)",
            "description" => "Экран 15.6\" IPS (1920x1080) Full HD, матовый / Intel Core i7-8750H (2.2 - 4.1 ГГц) / RAM 16 ГБ / HDD 1 ТБ + SSD 256 ГБ / nVidia GeForce GTX 1060, 6 ГБ / без ОД / Wi-Fi / Bluetooth / веб-камера / Windows 10 Home / 2.7 кг / черный",
            "price" => 41999,
            "promo_price" => 41199,
            "img" => "\img\_notebooks\_xiaomi_i7_16gb_1t_256gb_1060_6g_5bdc73086cb5d_images_8408755252.jpg"
        );
        $array[] = array(
            "name" => "Dell Vostro 15 3568 (N066VN3568_UBU) Black",
            "description" => "Экран 15.6\" (1920x1080) Full HD, матовый / Intel Core i5-7200U (2.5 - 3.1 ГГц) / RAM 8 ГБ / SSD 256 ГБ / Intel HD Graphics 620 / DVD+/-RW / LAN / Wi-Fi / Bluetooth / веб-камера / Linux / 2.18 кг / черный",
            "price" => 18999,
            "promo_price" => 16799,
            "img" => "\img\_notebooks\_dell_n066vn3568emea01_u_5b4dd336e7e89_images_5874740712.jpg"
        );
        $array[] = array(
            "name" => "Asus VivoBook X510UA-BQ441 (90NB0FQ3-M06790) Red",
            "description" => "Экран 15.6\" IPS (1920x1080) Full HD, матовый / Intel Core i5-8250U (1.6 - 3.4 ГГц) / RAM 8 ГБ / SSD 256 ГБ / Intel UHD Graphics 620 / без ОД / Wi-Fi / Bluetooth 4.2 / веб-камера / Endless OS / 1.7 кг / красный",
            "price" => 19127,
            "promo_price" => 17999,
            "img" => "\img\_notebooks\_asus_vivobook_x510ua_bq441_90nb0fq3_m06790_images_7174829544.jpg"
        );
        $array[] = array(
            "name" => "Lenovo IdeaPad 320-15IKB (80XL03GXRA) Onyx Black",
            "description" => "Экран 15.6\" (1920x1080) Full HD, матовый / Intel Pentium 4415U (2.3 ГГц) / RAM 8 ГБ / SSD 256 ГБ / nVidia GeForce GT 940MX, 2 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / DOS / 2.2 кг / черный",
            "price" => 13999,
            "promo_price" => 12999,
            "img" => "\img\_notebooks\_lenovo_80xl03gvra_59ef1a46574fe_images_2290609749.jpg"
        );
        $array[] = array(
            "name" => "HP ProBook 450 G5 (4QW15ES) Silver",
            "description" => "Экран 15.6\" (1920х1080) Full HD, матовый / Intel Core i5-8250U (1.6 - 3.4 ГГц) / RAM 8 ГБ / SSD 256 ГБ / Intel UHD 620 / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / DOS / 2.1 кг / серебристый",
            "price" => 24999,
            "promo_price" => 22999,
            "img" => "\img\_notebooks\_hp_3gh47es_5b8407951ccc0_images_6971257032.jpg"
        );
        return $array;
    }

    function get_smartphones_list() {

        $array[] = array(
            "name" => "Huawei P Smart 2019 3/64GB Aurora Blue (51093FTA)",
            "description" => "Экран (6.21\", IPS, 2340x1080)/ HiSilicon Kirin 710 (4 x 2.2 ГГц + 4 x 1.7 ГГц)/ две основные камеры: 13 Мп + 2 Мп, фронтальная камера: 8 Мп/ RAM 3 ГБ/ 64 ГБ встроенной памяти + microSD (до 512 ГБ)/ 3G/ LTE/ GPS/ GLONASS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 9.0 (Pie)/ 3400 мА*ч",
            "price" => 6699,
            "promo_price" => 6499,
            "img" => "\img\_phones\_huawei_p_smart_2019_blue_images_9396113454.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy A5 2017 Duos SM-A520 Black",
            "description" => "Экран (5.2\", Super AMOLED, 1920x1080)/ Samsung Exynos 7880 (1.9 ГГц)/ основная камера: 16 Мп, фронтальная камера: 16 Мп/ RAM 3 ГБ/ 32 ГБ встроенной памяти + microSD/SDHC (до 256 ГБ)/ 3G/ LTE/ GPS/ ГЛОНАСС/ поддержка 2х SIM-карт (Nano-SIM)/ Android 6.0 (Marshmallow)/ 3000 мА*ч",
            "price" => 7499,
            "promo_price" => 6999,
            "img" => "\img\_phones\_samsung_sm_a520fzdsek_images_1828043077.jpg"
        );
        $array[] = array(
            "name" => "Xiaomi Redmi 6A 2/16GB Black",
            "description" => "Экран (5.45\", IPS, 1440x720)/ MediaTek Helio A22 (2.0 ГГц)/ основная камера: 13 Мп, фронтальная камера: 5 Мп/ RAM 2 ГБ/ 16 ГБ встроенной памяти + microSD (до 256 ГБ)/ 3G/ LTE/ GPS/ GLONASS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo) / 3000 мА*ч",
            "price" => 3199,
            "promo_price" => 2999,
            "img" => "\img\_phones\_xiaomi_redmi_6a_2_16gb_black_images_6845976742.jpg"
        );
        $array[] = array(
            "name" => "Huawei P Smart+ Black",
            "description" => "Экран (6.3\", IPS, 2340x1080)/ HiSilicon Kirin 710 (2.2 ГГц + 1.7 ГГц)/ двойная основная камера: 16 Мп + 2 Мп, двойная фронтальная камера: 24 Мп + 2 Мп/ RAM 4 ГБ/ 64 ГБ встроенной памяти + microSD (до 256 ГБ)/ 3G/ LTE/ A-GPS/ ГЛОНАСС/ BDS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo)/ 3340 мА*ч",
            "price" => 8299,
            "promo_price" => 7999,
            "img" => "\img\_phones\_huawei_p_smart_plus_black_images_7926541605.jpg"
        );
        $array[] = array(
            "name" => "Nokia 5 Dual Sim Tempered Blue",
            "description" => "Экран (5.2\", IPS, 1280x720)/ Qualcomm Snapdragon 430 (1.4 ГГц)/ основная камера: 13 Мп, фронтальная камера: 8 Мп/ RAM 2 ГБ/ 16 ГБ встроенной памяти + microSD/SDHC (до 128 ГБ)/ 3G/ LTE/ GPS/ NFC поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo) / 3000 мА*ч",
            "price" => 4799,
            "promo_price" => 3599,
            "img" => "\img\_phones\_nokia_5_ds_blue_images_1946757884.jpg"
        );
        $array[] = array(
            "name" => "Asus ZenFone 4 Max 2/16GB (ZC520KL-4A045WW) Dual Sim Black",
            "description" => "Экран (5.2\", IPS, 1280x720)/ Qualcomm Snapdragon 425 (1.4 ГГц)/ основная камера: 13 Мп + 5 Мп, фронтальная камера: 8 Мп/ RAM 2 ГБ/ 16 ГБ встроенной памяти + microSD/SDHC (до 256 ГБ)/ 3G/ LTE/ GPS/ A-GPS/ ГЛОНАСС/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo) / 4100 мА*ч",
            "price" => 4399,
            "promo_price" => 3799,
            "img" => "\img\_phones\_asus_zenfone_4_max_zc554kl_4a067ww_5ab90d220680f_images_3737471435.jpg"
        );
        $array[] = array(
            "name" => "Xiaomi Redmi Note 5 3/32GB Black (Global Rom + OTA)",
            "description" => "Экран (5.99\", IPS, 2160x1080)/ Qualcomm Snapdragon 636 (1.8 ГГц)/ основная камера: 12 Мп + 5 Мп, фронтальная камера: 13 Мп/ RAM 3 ГБ/ 32 ГБ встроенной памяти + microSD (до 128 ГБ)/ 3G/ LTE/ GPS/ GLONASS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo)/ 4000 мА*ч",
            "price" => 4599,
            "promo_price" => 4350,
            "img" => "\img\_phones\_xiaomi_redmi_note5_332gb_black_images_5031666312.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy S8 64GB Midnight Black",
            "description" => "Экран (5.8\", Super AMOLED, 2960х1440)/ Samsung Exynos 8895 (4 x 2.3 ГГц + 4 x 1.7 ГГц)/ основная камера 12 Мп + фронтальная 8 Мп/ RAM 4 ГБ/ 64 ГБ встроенной памяти + microSD (до 256 ГБ)/ 3G/ LTE/ GPS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 7.0 (Nougat) / 3000 мА*ч",
            "price" => 19999,
            "promo_price" => 17999,
            "img" => "\img\_phones\_samsung_galaxy_s8_64gb_black_images_1894533392.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy A7 2018 4/64GB SM-A750 Blue",
            "description" => "Экран (6\", Super AMOLED, 2220x1080)/ Samsung Exynos 7885 (2.2 ГГц + 1.6 ГГц)/ основная тройная камера: 24 Мп + 8 Мп + 5 Мп, фронтальная камера: 24 Мп/ RAM 4 ГБ/ 64 ГБ встроенной памяти + microSD (до 512 ГБ)/ 3G/ LTE/ GPS/ ГЛОНАСС/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.0 (Oreo)/ 3300 мА*ч",
            "price" => 9999,
            "promo_price" => 9499,
            "img" => "\img\_phones\_samsung_sm_a750fzbusek_images_7811803866.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy S9 Plus 64GB Midnight Black",
            "description" => "Экран (6.2\", Super AMOLED, 2960х1440)/ Samsung Exynos 9810 (4 x 2.7 ГГц + 4 x 1.7 ГГц)/ двойная основная камера: 12 Мп + 12 Мп, фронтальная: 8 Мп/ RAM 6 ГБ/ 64 ГБ встроенной памяти + microSD (до 400 ГБ)/ 3G/ LTE/ GPS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.0 (Oreo) / 3500 мА*ч",
            "price" => 29999,
            "promo_price" => 27999,
            "img" => "\img\_phones\_samsung_galaxy_s9_plus_64gb_black_images_3249706863.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy A6+ SM-A605 3/32GB Black (SM-A605FZKNSEK)",
            "description" => "Экран (6\", Super AMOLED, 2220x1080)/ Qualcomm Snapdragon 450 (1.8 ГГц)/ Двойная основная камера: 16 + 5 Мп, фронтальная камера: 24 Мп/ RAM 3 ГБ/ 32 ГБ встроенной памяти + microSD (до 256 ГБ)/ 3G/ 4G/ GPS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.0 (Oreo)/ 3500 мА*ч",
            "price" => 10000,
            "promo_price" => 8999,
            "img" => "\img\_phones\_samsung_sm_a605fzknsek_images_4579524680.jpg"
        );
        $array[] = array(
            "name" => "Huawei P20 4/64GB Twilight",
            "description" => "Экран (5.8\", IPS, 2244x1080)/ HiSilicon Kirin 970 (4 ядра 2.36 ГГц + 4 ядра 1.8 ГГц)/ две основные камеры: 20 Мп + 12 Мп, фронтальная камера: 24 Мп/ RAM 4 ГБ/ 64 ГБ встроенной памяти / 3G/ LTE/ GPS/ GLONASS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo)/ 3400 мА*ч",
            "price" => 16499,
            "promo_price" => 14999,
            "img" => "\img\_phones\_huawei_p20_4_64gb_twilight_images_7654450998.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy Note 9 6/128GB Midnight Black",
            "description" => "Экран (6.4\", Super AMOLED, 2960х1440)/ Samsung Exynos 9810 (Quad 2.7 ГГц + Quad 1.7 ГГц)/ двойная основная камера: 12 Мп + 12 Мп, фронтальная: 8 Мп/ RAM 6 ГБ/ 128 ГБ встроенной памяти + microSD (до 512 ГБ)/ 3G/ LTE/ GPS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo) / 4000 мА*ч",
            "price" => 34999,
            "promo_price" => 32999,
            "img" => "\img\_phones\_samsung_sm_n960fzkdsek_images_6520779374.jpg"
        );
        $array[] = array(
            "name" => "Xiaomi Mi A1 4/32GB Dual Sim Rose Gold (Международная версия)",
            "description" => "Экран (5.5\", IPS, 1920x1080)/ Qualcomm Snapdragon 625 (2.0 ГГц)/ Двойная основная камера: 12 Мп + 12 Мп, фронтальная камера: 5 Мп/ RAM 4 ГБ/ 32 ГБ встроенной памяти + microSD (до 128 ГБ)/ 3G/ LTE/ GPS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 7.1 (Nougat) / 3080 мА*ч",
            "price" => 4520,
            "promo_price" => 4399,
            "img" => "\img\_phones\_xiaomi_mi_a1_4_32g_rose_gold_eur_images_4214052304.jpg"
        );
        $array[] = array(
            "name" => "TP-Link Neffos C9a (TP706A24UA) Cloudy Grey",
            "description" => "Экран (5.45\", IPS, 1440x720)/ MediaTek MTK6739WW (1.5 ГГц) / основная камера: 13 Мп, фронтальная камера: 5 Мп/ RAM 2 ГБ/ 16 ГБ встроенной памяти + microSD (до 128 ГБ)/ 3G/ LTE/ GPS/ A-GPS/ ГЛОНАСС/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo) / 3020 мА*ч",
            "price" => 2999,
            "promo_price" => 2599,
            "img" => "\img\_phones\_tp_link_tp706a24ua_images_6301342886.jpg"
        );
        $array[] = array(
            "name" => "Huawei P20 Pro 6/128GB Twilight",
            "description" => "Экран (6.1\", OLED, 2240x1080)/ HiSilicon Kirin 970 (4 ядра 2.36 ГГц + 4 ядра 1.8 ГГц)/ три основные камеры: 40 Мп + 20 Мп + 8 Мп, фронтальная камера: 24 Мп/ RAM 6 ГБ/ 128 ГБ встроенной памяти + microSD/SDHC (до 256 ГБ)/ 3G/ LTE/ GPS/ GLONASS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo)/ 4000 мА*ч",
            "price" => 26899,
            "promo_price" => 24999,
            "img" => "\img\_phones\_huawei_p20_pro_6_128gb_twilight_images_4627037512.jpg"
        );
        $array[] = array(
            "name" => "Sony Xperia XA1 Plus Dual (G3412) Black",
            "description" => "Экран (5.5\", IPS, 1920x1080)/ MediaTek Helio P20 (4 x 2.3 ГГц + 4 x 1.6 ГГц)/ основная камера: 23 Мп, фронтальная камера: 8 Мп/ RAM 4 ГБ/ 32 ГБ встроенной памяти + microSD/SDXC (до 256 ГБ)/ 3G/ LTE/ GPS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 7.0 (Nougat)/ 3430 мА*ч",
            "price" => 5999,
            "promo_price" => 4999,
            "img" => "\img\_phones\_sony_xperia_xa1_plus_dual_black_images_2268112224.jpg"
        );
        $array[] = array(
            "name" => "Meizu M5 Note 32GB Grey",
            "description" => "Экран (5.5\", LTPS, 1920x1080)/ MediaTek Helio P10 (4x1.8 ГГц + 4x1.0 ГГц)/ основная камера: 13 Мп, фронтальная камера: 5 Мп/ RAM 3 ГБ/ 32 ГБ встроенной памяти + microSD/SDHC (до 128 ГБ)/ 3G/ LTE/ GPS/ поддержка 2х SIM-карт (Nano-SIM)/Android 6.0 (Marshmallow) / 4000 мА*ч",
            "price" => 3899,
            "promo_price" => 3199,
            "img" => "\img\_phones\_meizu_m5_note_16gb_grey_euromart_58de3dd19c6ee_images_1897104765.jpg"
        );
        $array[] = array(
            "name" => "Asus ZenFone Max Pro (M1) 4/64GB ZB602KL-4A085WW Dual Sim Black",
            "description" => "Экран (6.0\", IPS, 2160x1080)/ Qualcomm Snapdragon 636 (1.8 ГГц)/ основная камера: 13 Мп + 5 Мп, фронтальная камера: 8 Мп/ RAM 4 ГБ/ 64 ГБ встроенной памяти + microSD/SDHC (до 2 ТБ)/ 3G/ LTE/ GPS/ A-GPS/ ГЛОНАСС/ BDS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (Oreo) / 5000 мА*ч",
            "price" => 7999,
            "promo_price" => 6599,
            "img" => "\img\_phones\_asus_90ax00t1_m00970_images_6271862254.jpg"
        );
        $array[] = array(
            "name" => "Xiaomi Mi 8 6/64GB Black",
            "description" => "Экран (6.21\", Super AMOLED, 2248×1080)/ Qualcomm Snapdragon 845 (4x2.8 ГГц + 4x1.8 ГГц)/ Двойная основная камера: 12 Мп + 12 Мп, фронтальная камера: 20 Мп/ RAM 6 ГБ/ 64 ГБ встроенной памяти/ 3G/ LTE/ GPS/ поддержка 2х SIM-карт (Nano-SIM)/ Android 8.1 (МIUI 10)/ 3400 мА*ч",
            "price" => 14999,
            "promo_price" => 11999,
            "img" => "\img\_phones\_xiaomi_mi8_664_blk_images_5462775504.jpg"
        );

        return $array;
    }

    function get_tablets_list() {

        $array[] = array(
            "name" => "Lenovo Tab 7 Essential TB-7304i 3G 2/16GB NBC Black (ZA310144UA)",
            "description" => "Экран 7\" IPS (1024х600), MultiTouch / MediaTek MT8167D (1.3 ГГц) / RAM 2 ГБ / 16 ГБ встроенной памяти + microSD / Wi-Fi / 3G / Bluetooth 4.0 / основная камера 2 Мп + фронтальная - 2 Мп / A-GPS / Android 7.0 (Nougat) / 254 г / черный",
            "price" => 3699,
            "promo_price" => 3499,
            "img" => "\img\_tablets\_lenovo_tab4_za310064ua_5a6ae71913ad2_images_2694275743.jpg"
        );
        $array[] = array(
            "name" => "Pixus Vision 10.1 3G 3/16GB",
            "description" => "Экран 10.1\" IPS (1920x1200) MultiTouch / MediaTek MT6753 (1.3 ГГц) / RAM 3 ГБ / 16 ГБ встроенной памяти + microSD / 3G / LTE / Wi-Fi / Bluetooth 4.0 / основная камера 5 Мп, фронтальная - 2 Мп / GPS / A-GPS / поддержка 2-х СИМ-карт / Android 7.0 (Nougat) / 450 г / черный",
            "price" => 4299,
            "promo_price" => 4100,
            "img" => "\img\_tablets\_pixus_vision_10_1_3g_3_16g_images_2828805767.jpg"
        );
        $array[] = array(
            "name" => "Prestigio MultiPad Wize 3171 3G Black (PMT3171_3G_D)",
            "description" => "Экран 10.1\" IPS (1280x800) емкостный, Multi-Touch / MediaTek MT8321 (1.3 ГГц) / RAM 1 ГБ / 16 ГБ встроенной памяти + поддержка карт памяти microSD / 3G / Wi-Fi / Bluetooth / основная камера 2 Мп, фронтальная - 0.3 Мп / Android 7.0 (Nougat) / 498 г / черный",
            "price" => 2899,
            "promo_price" => 2599,
            "img" => "\img\_tablets\_prestigio_pmt3171_3g_d_images_9220153327.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy Tab A 10.1\" Black (SM-T580NZKASEK)",
            "description" => "Экран 10.1\" (1920х1200) емкостный MultiTouch / Exynos 7870 (1.6 ГГц) / RAM 2 ГБ / 16 ГБ встроенной памяти + microSD / Wi-Fi 802.11 a/b/g/n/ac / Bluetooth 4.1 / основная камера 8 Мп, фронтальная 2 Мп / GPS / ГЛОНАСС / Android 6.0 (Marshmallow) / 525 г / черный",
            "price" => 6999,
            "promo_price" => 6499,
            "img" => "\img\_tablets\_samsung_sm_t580nzkasek_images_1643374373.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy Tab A 8.0 16GB LTE Black (SM-T385NZKASEK)",
            "description" => "Экран 8.0\" IPS (1280x800) емкостный MultiTouch / Qualcomm Snapdragon 425 APQ8917 (1.4 ГГц) / RAM 2 ГБ / 16 ГБ встроенной памяти + поддержка карт памяти microSD / 3G / LTE / Wi-Fi / Bluetooth / основная камера 8 Мп, фронтальная 5 Мп / GPS / ГЛОНАСС / Android 7.1 (Nougat) / 364 г / черный",
            "price" => 7299,
            "promo_price" => 6999,
            "img" => "\img\_tablets\_samsung_sm_t385nzsasek_59fc0be6df26a_images_2305633433.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy Tab E 9.6\" 3G Black (SM-T561NZKASEK)",
            "description" => "Экран 9.6\" (1280x800) емкостный MultiTouch / T-Shark2 (1.3 ГГц) / RAM 1.5 ГБ / 8 ГБ встроенной памяти + microSD / 3G / Wi-Fi 802.11a/b/g/n / Bluetooth 4.0 / основная камера 5 Мп, фронтальная 2 Мп / GPS / ГЛОНАСС / Android 4.4 (KitKat) / 490 г / черный",
            "price" => 4999,
            "promo_price" => 4699,
            "img" => "\img\_tablets\_samsung_galaxy_tab_e_3g_black_images_749133880.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy Tab A 10.1\" LTE Black (SM-T585NZKASEK)",
            "description" => "Экран 10.1\" (1920х1200) емкостный MultiTouch / Exynos 7870 (1.6 ГГц) / RAM 2 ГБ / 16 ГБ встроенной памяти + microSD / 3G / LTE / Wi-Fi 802.11 a/b/g/n/ac / Bluetooth 4.1 / основная камера 8 Мп, фронтальная 2 Мп / GPS / ГЛОНАСС / Android 6.0 (Marshmallow) / 525 г / черный",
            "price" => 8499,
            "promo_price" => 7999,
            "img" => "\img\_tablets\_samsung_sm_t585nzkasek_images_1643368731.jpg"
        );
        $array[] = array(
            "name" => "Lenovo Tab 4 10 LTE 16GB Slate Black (ZA2K0054UA)",
            "description" => "Экран 10.1\" (1280x800) IPS емкостный, MultiTouch / Qualcomm Snapdragon MSM8917 (1.4 ГГц) / RAM 2 ГБ / 16 ГБ встроенной памяти + microSD / Wi-Fi b/g/n / Bluetooth 4.0 / 3G / LTE / основная камера 5 Мп, фронтальная - 2 Мп / GPS / ГЛОНАСС / Android 7.0 (Nougat) / 505 г / черный",
            "price" => 5999,
            "promo_price" => 5699,
            "img" => "\img\_tablets\_lenovo_za2k0054ua_images_2084096623.jpg"
        );
        $array[] = array(
            "name" => "Asus ZenPad 3S 10 4/64GB Gray (Z500M-1H014A)",
            "description" => "Экран 9.7\" IPS (2048x1536) емкостный MultiTouch / MediaTek MT8176 (2.1 ГГц + 1.7 ГГц) / RAM 4 ГБ / 64 ГБ встроенной памяти + microSD / Wi-Fi 802.11 a/b/g/n/ac / Bluetooth 4.2 / основная камера 8 Мп, фронтальная - 5 Мп / GPS / ГЛОНАСС / ОС Android 6.0 (Marshmallow) / 466 г / серый",
            "price" => 9599,
            "promo_price" => 8999,
            "img" => "\img\_tablets\_asus_z500m_1h014a_images_1691674485.jpg"
        );
        $array[] = array(
            "name" => "Nomi Ultra 3 LTE 10\" 16GB C101030 Black",
            "description" => "Экран 10\" IPS (1280x800) MultiTouch / MediaTek MTK8321 (1.2 ГГц) / RAM 1 ГБ / 16 ГБ встроенной памяти + microSD / 3G / 4G / LTE / Wi-Fi / Bluetooth / основная камера 2 Мп + фронтальная 0.3 Мп / GPS / поддержка 2-х СИМ-карт / Android 7.0 (Nougat) / 513 г / черный",
            "price" => 3100,
            "promo_price" => 2999,
            "img" => "\img\_tablets\_nomi_ultra_3_c101030_black_images_2768991527.jpg"
        );
        $array[] = array(
            "name" => "Samsung Galaxy Tab A 7.0\" LTE Black (SM-T285NZKASEK)",
            "description" => "Экран 7.0\" (1280х800) емкостный MultiTouch / Spreadtrum (1.5 ГГц) / RAM 1.5 ГБ / 8 ГБ встроенной памяти + поддержка карт памяти microSD / 3G / LTE / Wi-Fi 802.11 b/g/n / Bluetooth 4.1 / основная камера 5 Мп, фронтальная 2 Мп / GPS / ГЛОНАСС / Android 5.1 (Lollipop) / 285 г / Черный",
            "price" => 4499,
            "promo_price" => 3999,
            "img" => "\img\_tablets\_samsung_sm_t285nzkasek_images_1467239890.jpg"
        );
        $array[] = array(
            "name" => "Bravis NB106M 10.1” 3G Black",
            "description" => "Экран 10.1\" IPS (1280х800) MultiTouch / MediaTek 8321 (1.3 ГГц) / RAM 1 ГБ / 16 ГБ встроенной памяти + microSD / 3G / Wi-Fi / Bluetooth 4.0 / основная камера 2 Мп + фронтальная 0.3 Мп / GPS / A-GPS / поддержка 2-х СИМ-карт / Android 7.0 (Nougat) / 520 г / черный",
            "price" => 2699,
            "promo_price" => 2499,
            "img" => "\img\_tablets\_bravis_nb106m_3g_black_images_2405641945.jpg"
        );
        $array[] = array(
            "name" => "Assistant AP-115G Taurus Black",
            "description" => "Экран 10.1\" IPS (1280x800) Multi-Touch / MediaTek MT8321 (1.3 ГГц) / RAM 2 ГБ / 16 ГБ встроенной памяти + поддержка microSD / 3G / Wi-Fi / Bluetooth / основная камера 5 Мп, фронтальная - 2 Мп / GPS / поддержка 2-х СИМ-карт / Android 7.0 (Nougat) / 535 г / черный",
            "price" => 3199,
            "promo_price" => 2999,
            "img" => "\img\_tablets\_assistant_ap115g_taurus_black_images_5747912216.jpg"
        );
        $array[] = array(
            "name" => "Huawei MediaPad M5 Lite 10\" 3/32GB LTE Grey (BAH2-L09)",
            "description" => "Экран 10.1\" IPS (1920x1200) MultiTouch / HiSilicon Kirin 659 (2.36 ГГц + 1.7 ГГц) / RAM 3 ГБ / 32 ГБ встроенной памяти + microSD / 3G / LTE / Wi-Fi / Bluetooth 4.2 / основная камера 8 Мп, фронтальная 8 Мп / GPS / ГЛОНАСС / поддержка 2-х СИМ-карт / Android 8.0 (EMUI) / 475 г / серый",
            "price" => 11000,
            "promo_price" => 10499,
            "img" => "\img\_tablets\_huawei_mediapad_m5_lite_10_3_32_grey_images_7611003948.jpg"
        );
        $array[] = array(
            "name" => "Impression ImPAD B702",
            "description" => "Экран 7\" IPS (1024х600), MultiTouch / Spreadtrum SC7731C (1.2 ГГц) / RAM 1 ГБ / 8 ГБ встроенной памяти + microSD (до 64 ГБ) / 3G / Wi-Fi / Bluetooth / основная камера 5 Мп, фронтальная 2 Мп / GPS / Android 6.0 (Marshmallow) / 260 г / черный",
            "price" => 1999,
            "promo_price" => 1699,
            "img" => "\img\_tablets\_impression_impad_b702_images_2104004392.jpg"
        );
        $array[] = array(
            "name" => "Cube Talk9X (U65GT_16)",
            "description" => "Экран 9.7\" IPS (2048х1536) емкостный Multi-Touch / MediaTek MT8392 (2 ГГц) / ОЗУ 2 ГБ / встроенная память 16 ГБ + поддержка карт памяти microSD (до 128 ГБ) / 3G / Wi-Fi / Bluetooth 4.0 / основная камера 8 Мп, фронтальная 2 Мп / GPS / ОС Android 4.4.2 (KitKat) / 560 г",
            "price" => 3899,
            "promo_price" => 3399,
            "img" => "\img\_tablets\_cube_u65gt_16__images_8936343519.jpg"
        );

        return $array;
    }
?>
