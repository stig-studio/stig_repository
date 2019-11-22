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
    <body>
    <?php
        echo'   
        <form method="post" action="" class="form-horizontal" id="main_form">
            <div class="form-group">
                <label for="inp_r" class="control-label col-xs-2">R</label>
                <div class="col-xs-10">
                    <input type="text" class="form-control" name="inp_r" id="inp_r_"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inp_g" class="control-label col-xs-2">G</label>
                <div class="col-xs-10">
                    <input type="text" class="form-control" name="inp_g" id="inp_g_"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inp_b" class="control-label col-xs-2">B</label>
                <div class="col-xs-10">
                    <input type="text" class="form-control" name="inp_b" id="inp_b_"/>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-offset-2 col-xs-10">
                    <input type="button" class="btn btn-primary" id="btn_accept" value="Accept"/>
                </div>
            </div>
        </form>
        <span id="b_out" class="blk_out">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit.
            Animi aut dignissimos error impedit incidunt itaque minima mollitia nemo, nihil, officia, sequi ut voluptatum.
            Autem consequuntur expedita impedit nulla obcaecati, qui!
        </span>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
        <script src="js\script.js"></script>';
    ?>
    </body>
</html>