
var config = require( 'config' );
var TelegramBot = require( 'node-telegram-bot-api' );
var request = require( 'request' );

const TOKEN_BOT = config.get( 'token_bot' );
console.log( "bot token: " + TOKEN_BOT );

const bot = new TelegramBot( TOKEN_BOT,
    { polling: true } );

// bot.on( 'message', msg => {

//     // const chat_id = msg.chat.id;
//     // bot.sendMessage( chat_id, 'Привет! ' + msg.chat.first_name + " " + msg.chat.last_name + "!\n" );

//     answer = '';
//     console.log( msg.text );
//     if ( msg.text == '/start' )   {
//             answer =  'Здравствуй, '
//                 + msg.chat.first_name + ' ' + msg.chat.last_name+ '!\n'                     
//                 + 'Сыграем в игру: камень-ножницы-бумага?\n'
//                 + '/stone - твой камень\n'
//                 + '/scissors - твои ножницы\n'
//                 + '/paper - твоя бумага\n';
//             }    
//     bot.sendMessage(chatId, answer);

// } );

bot.on( 'message', ( msg ) => {
    const chatId = msg.chat.id; 
    answer = '';    console.log( msg.text );
    if ( msg.text == '/start' ) {
                answer =  'Здравствуй, '
                    + msg.chat.first_name + ' ' + msg.chat.last_name+ '!\n'                     
                    + 'Сыграем в игру: камень-ножницы-бумага?\n'
                    + '/stone - твой камень\n'
                    + '/scissors - твои ножницы\n'
                    + '/paper - твоя бумага\n';
            }    
    bot.sendMessage( chatId, answer );
  } );

  bot.on( 'message', ( msg ) => {

    const chatId = msg.chat.id; 
    answer = '';    console.log( msg.text );

    if (msg.text == '/start')   {
                answer =  'Здравствуй, '
                    + msg.chat.first_name + ' ' + msg.chat.last_name+ '!\n'                     
                    + 'Сыграем в игру: камень-ножницы-бумага?\n'
                    + '/stone - твой камень\n'
                    + '/scissors - твои ножницы\n'
                    + '/paper - твоя бумага\n';
            }    
    bot.sendMessage( chatId, answer );    
  } );

bot.onText( /\/stone/, function ( msg, match ) {
    var userId = msg.from.id;
    bot.sendMessage( userId, 'А у меня бумага - ты проиграл!' );
} );

bot.onText( /\/scissors/, function ( msg, match ) {
    var userId = msg.from.id;
    bot.sendMessage( userId, 'А у меня камень - ты проиграл!' );
} );

bot.onText( /\/paper/, function ( msg, match ) {
    var userId = msg.from.id;
    bot.sendMessage( userId, 'А у меня ножницы - ты проиграл!' );
} );


bot.onText( /\/curse/, function ( msg, match ) {

    var userId = msg.from.id    
    bot.sendMessage( userId, 'Какая валюта вас интересует?', {
        reply_markup:{
            inline_keyboard : [
                [
                    {   text: 'EUR', callback_data: 'EUR' },
                    {   text: 'USD', callback_data: 'USD' },
                    {   text: 'BTC', callback_data: 'BTC' }
                ]
            ]
        }
    } );
} );

bot.on( 'callback_query', query => {

    const id = query.message.chat.id;

    request('https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5'
            , function(error, response, body)  {
                const data =JSON.parse(body);
                const result = 
                    data.filter(item => item.ccy === query.data)[0];
                let md = `
                    *${result.ccy} => ${result.base_ccy}*
                    Buy: _${result.buy}_
                    Sale: _${result.sale}_
                `;
                bot.sendMessage(id, md, {parse_mode: 'Markdown'});
            })

} );

bot.onText(/\/weather (.+)/, function (msg, match) {
    var userId = msg.from.id;
    var token_owm = config.get('token_open_weather_map');
    var url_owm = config.get('url_open_weather_map');
    var city = match[1];
    request(url_owm+'?q='+city+'&appid='+token_owm
        ,function(error, response, body){
            const data =JSON.parse(body);         
                let md = `
                    *${data['name']} : *
                    Температура: _${data.main['temp']/10}_
                    Давление: _${data.main['pressure']}_
                    Влажность: _${data.main['humidity']}_
                `;
                bot.sendMessage(userId, md, {parse_mode: 'Markdown'});                
        });
});