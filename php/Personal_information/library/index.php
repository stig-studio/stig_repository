
<?php
    include "func.php";
?>


<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
    <table class="table">
        <thead class="thead-inverse">
            <tr>
            <th>#</th>
            <th>Обложка</th>
            <th>Автор</th>
            <th>Название книги</th>
            </tr>
        </thead>
        <tbody>
        <?php
                $arr_books = get_books_list();

                if( count( $Aarr_books > 0 ) ) {

                    foreach ( $arr_books as $book ) {
                        echo '<tr>
                            <th scope="row">'.$book[0].'</th><td><image src="img/'.$book[0].'.jpg" width="60" height="80"></td><td>'.$book[1].'</td><td>'.$book[2].'</td>
                            </tr>';
                    }
                }
            ?>
            
        </tbody>
    </table>
</body>
</html>