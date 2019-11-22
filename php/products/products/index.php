<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="css\style.css">
    <title>Document</title>
</head>
    <?

//    include "data.php";
//
//    $notebooks = get_notebooks_list();

    echo '
    <div class="page">
        <div class="menu_panel">
            <button class="menu_btn" id="btn_notebooks" name="btn_notebooks">Ноутбуки</button>
            <button class="menu_btn" id="btn_phones" name="btn_phones">Смартфоны</button>
            <button class="menu_btn" id="btn_tablets" name="btn_tablets">Планшеты</button>
            <span class="search"><input type="text" name="inp_search" id="inp_search" class="inp_search" placeholder="Поиск..."></span>
        </div>
        <div>
            <div class="filter">            
                <a>Цена от: </a><input type="text" id="price_from" name="price_from" class="filter_inp">
                <a> до: </a><input type="text" id="price_to" name="price_to" class="filter_inp">
                <button id="btn_filter">ФИЛЬТРОВАТЬ</button>            
            </div>
        </div>
        
        <div class="products">';
    echo '
        </div>
    </div>
    '?>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
    <script src="js/script.js"></script>
    </body>
</html>