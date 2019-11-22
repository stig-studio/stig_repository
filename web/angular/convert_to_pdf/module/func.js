
var months = [
    'Січень',
    'Лютень',
    'Березень',
    'Квітень',
    'Травень',
    'Червень',
    'Липень',
    'Серпень',
    'Вересень',
    'Жовтень',
    'Листопад',
    'Грудень'
];

function get_month( month ) {
    return months[month];
}

function add_zeros( num ) {
    var s = "00000" + num;
    var res = s.substr( s.length - 5, s.length );
    return res;
}

module.exports.get_month = get_month;
module.exports.add_zeros = add_zeros;