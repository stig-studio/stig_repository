<?php

    $month = $_POST[ "list_months" ]; // номер месяца

    show_calendar( $month );

    function show_calendar( $month ) {

        $curr_year = date( "Y" );   // текущий год
        $curr_day = date( "d" );    // текущий день
        $curr_month = date( "m" );  // текущий месяц

        $quantity_day = cal_days_in_month( CAL_GREGORIAN, $month, $curr_year ); // к-во дней в месяце

        $calendar = "<table class='table_calendar'>
                    <tr>
                        <td>Пн</td>
                        <td>Вт</td>
                        <td>Ср</td>
                        <td>Чт</td>
                        <td>Пт</td>
                        <td>Сб</td>
                        <td>Вс</td>
                    </tr>";

        echo $calendar;

        $week = 0;  // неделя месяца

        for( $i = 1; $i <= $quantity_day; $i++ ) {

            if ( $week == 0 ) {

                echo "<tr>";

                $day_week = date("N", mktime(0, 0, 0, $month, $i, $curr_year));

                for ( $k = 1; $k < $day_week; $k++ )
                    echo "<td></td>";

                for ( $j = $day_week; $j <= 7; $j++ ) {
                    if( $j == $curr_day && $month == $curr_month )
                        echo "<td class='curr_day'>" . $i++ . "</td>";
                    echo "<td>" . $i++ . "</td>";
                }

                $week++;

                echo "</tr>";
            }

            echo "<tr>";

            if( $i + 7 <= $quantity_day ) {
                for( $j = $i; $j < $i + 7; $j++ ) {
                    if( $j == $curr_day && $month == $curr_month )
                        echo "<td class='curr_day'>" . $j . "</td>";
                    else
                        echo "<td>" . $j . "</td>";
                }
                $i += 6;
            }
            else {
                for( $j = $i; $j <= $quantity_day; $j++ )
                    if( $j == $curr_day )
                        echo "<td class='curr_day'>" . $j . "</td>";
                    else
                        echo "<td>".$j."</td>";
                $i += $quantity_day - $i;
            }
            echo "</tr>";
        }
        echo "</table>";
    }
?>
