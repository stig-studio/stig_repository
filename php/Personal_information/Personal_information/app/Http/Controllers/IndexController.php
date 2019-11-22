<?php

namespace App\Http\Controllers;

//use Illuminate\Http\Request;

use App\Person;

class IndexController extends Controller {

    public function index() {

        $persons = Person::select( 'id', 'FullName', 'BirthDay' )->get();

        return view( 'page' )->with( 'persons', $persons );
    }

}
