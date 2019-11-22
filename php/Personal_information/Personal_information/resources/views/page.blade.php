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
        <th>ФИО</th>
        <th>Дата рождения</th>
    </tr>
    </thead>
    <tbody>

    @foreach( $persons as $person )

        <tr>
            <th scope="row">{{$person->id}}</th>
            <td>{{$person->FullName}}</td>
            <td>{{$person->BirthDay}}</td>
        </tr>

    @endforeach

    </tbody>
</table>

</body>
</html>