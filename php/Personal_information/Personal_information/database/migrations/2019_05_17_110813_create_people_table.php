<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreatePeopleTable extends Migration {

    public function up() {

        Schema::create( 'people', function ( Blueprint $table ) {
            $table->bigIncrements( 'id' );
            $table->string( 'FullName', 100 );
            $table->date( 'Birthday' );
        } );
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down() {
        Schema::dropIfExists( 'people' );
    }
}
