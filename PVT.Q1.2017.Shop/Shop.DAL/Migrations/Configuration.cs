namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Infrastructure.Enums;

    using Shop.Common.Models;
    using Shop.DAL.Context;

    /// <summary>
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Configuration" /> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        protected override void Seed(ShopContext context)
        {
            this.AddDefaultCurrencies(context);
            this.AddDefaultCurrencyRates(context);
            this.AddDefaultGenres(context);
            this.AddDefaultPriceLevels(context);
            this.AddDefaultCountries(context);
#if DEBUG
            AddDefaultUsers(context);
            AddDefaultArtistsAndTracks(context);
            AddDefaultPurchasedItems(context);
#endif
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultAlbums(ShopContext context)
        {
            if (!context.Set<Album>().Any())
            {
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 1, Name = "Крыша дома твоего", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 5, Name = "Elements of life", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 5, Name = "Kaleidoscope", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 5, Name = "Just be", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 6, Name = "Delirium", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 7, Name = "More life", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 7, Name = "Views", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 7, Name = "Take care", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 8, Name = "Daydream", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 8, Name = "Emotions", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 8, Name = "Rainbow", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 15, Name = "Illuminate", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 15, Name = "Handwritten", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 15, Name = "Don`t be a fool", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 16, Name = "Joanne", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 16, Name = "Artpop", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 16, Name = "The fame", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 17, Name = "Sacred love", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 17, Name = "Ten summoners tales", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 17, Name = "The soul cage", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 18, Name = "Load", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 18, Name = "Garage inc.", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 18, Name = "S&M", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 19, Name = "Imagine", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 19, Name = "Mirage", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 19, Name = "Intence", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 20, Name = "Motion", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 20, Name = "18 month", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 20, Name = "I created disco", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 21, Name = "Girl", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 21, Name = "In my mind", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 21, Name = "Out of my mind", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 22, Name = "Organik", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 22, Name = "23am", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 22, Name = "Dreamland", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 23, Name = "Crossroads", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 23, Name = "I still do", OwnerId = 104 });
                context.Set<Album>().AddOrUpdate(new Album { ArtistId = 23, Name = "Blues", OwnerId = 104 });
                context.SaveChanges();

                context.Set<AlbumTrackRelation>()
                    .AddOrUpdate(
                        new AlbumTrackRelation { TrackId = 1, AlbumId = 1 },
                        new AlbumTrackRelation { TrackId = 2, AlbumId = 1 });
                context.SaveChanges();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultAlbumsPrices(ShopContext context)
        {
            if (!context.Set<AlbumPrice>().Any())
            {
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 1, CurrencyId = 1, Price = 14.99m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 2, CurrencyId = 1, Price = 12.58m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 3, CurrencyId = 1, Price = 11.44m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 4, CurrencyId = 1, Price = 10.99m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 5, CurrencyId = 1, Price = 10.12m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 6, CurrencyId = 1, Price = 14.22m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 7, CurrencyId = 1, Price = 9.54m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 8, CurrencyId = 1, Price = 12.32m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 9, CurrencyId = 1, Price = 5.45m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 10, CurrencyId = 1, Price = 7.88m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 11, CurrencyId = 1, Price = 9.29m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 12, CurrencyId = 1, Price = 11.46m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 13, CurrencyId = 1, Price = 10.28m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 14, CurrencyId = 1, Price = 9.45m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 15, CurrencyId = 1, Price = 7.24m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 16, CurrencyId = 1, Price = 7.41m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 17, CurrencyId = 1, Price = 9.22m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 18, CurrencyId = 1, Price = 12.15m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 19, CurrencyId = 1, Price = 10.14m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 20, CurrencyId = 1, Price = 16.40m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 21, CurrencyId = 1, Price = 4.12m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 22, CurrencyId = 1, Price = 6.10m, PriceLevelId = 1 });
                context.Set<AlbumPrice>()
                    .AddOrUpdate(new AlbumPrice { AlbumId = 23, CurrencyId = 1, Price = 7.55m, PriceLevelId = 1 });
                context.SaveChanges();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultArtistsAndTracks(ShopContext context)
        {
            if (!context.Set<Artist>().Any())
            {
                context.Set<Artist>()
                    .AddOrUpdate(
                        new Artist { Name = "Ю.Антонов" },
                        new Artist { Name = "И.Кабзон" },
                        new Artist { Name = "Bruno Mars" },
                        new Artist { Name = "Rihanna" },
                        new Artist { Name = "Tiesto" },
                        new Artist { Name = "Ellie Goulding" },
                        new Artist { Name = "Drake" },
                        new Artist { Name = "Mariah Carey" },
                        new Artist { Name = "Khalid" },
                        new Artist { Name = "Migos" },
                        new Artist { Name = "Skrillex" },
                        new Artist { Name = "Martin Garrix" },
                        new Artist { Name = "Maroon 5" },
                        new Artist { Name = "Justin Timberlake" },
                        new Artist { Name = "Shawn Mendes" },
                        new Artist { Name = "Lady Gaga" },
                        new Artist { Name = "Sting" },
                        new Artist { Name = "Mettalica" },
                        new Artist { Name = "Armin van Buuren" },
                        new Artist { Name = "Calvin Harris" },
                        new Artist { Name = "Pharell Williams" },
                        new Artist { Name = "Robert Miles" },
                        new Artist { Name = "Eric Clapton" },
                        new Artist { Name = "Modern Talking" },
                        new Artist { Name = "Enigma" },
                        new Artist { Name = "Kygo" },
                        new Artist { Name = "dj Snake" },
                        new Artist { Name = "MO" },
                        new Artist { Name = "James Arthur" },
                        new Artist { Name = "Katy Perry" },
                        new Artist { Name = "Ayo & Teo" },
                        new Artist { Name = "Jon Pardi" },
                        new Artist { Name = "Travis Scott" },
                        new Artist { Name = "Imagine Dragons" },
                        new Artist { Name = "Jason Aldean" },
                        new Artist { Name = "Lorde" },
                        new Artist { Name = "Childish Gambino" },
                        new Artist { Name = "Luke Combs" },
                        new Artist { Name = "Luke Bryan" },
                        new Artist { Name = "Logic" },
                        new Artist { Name = "Lady Antebellum" },
                        new Artist { Name = "Auli'i Cravalho" },
                        new Artist { Name = "Josh Turner" },
                        new Artist { Name = "Dierks Bentley" },
                        new Artist { Name = "Lauren Alaina" },
                        new Artist { Name = "Ed Sheeran" },
                        new Artist { Name = "Train" },
                        new Artist { Name = "J. Cole" },
                        new Artist { Name = "Big Sean" },
                        new Artist { Name = "Miranda Lambert" },
                        new Artist { Name = "Adele" });

                context.SaveChanges();

                this.AddDefaultTracks(context);
                this.AddDefaultAlbums(context);
                this.AddDefaultTracksPrices(context);
                this.AddDefaultAlbumsPrices(context);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultCurrencies(ShopContext context)
        {
            if (!context.Set<Currency>().Any(c => c.ShortName == "EUR"))
            {
                context.Set<Currency>().AddOrUpdate(new Currency { ShortName = "EUR", Code = 978, FullName = "EURO" });
            }

            if (!context.Set<Currency>().Any(c => c.ShortName == "USD"))
            {
                context.Set<Currency>()
                    .AddOrUpdate(new Currency { ShortName = "USD", Code = 840, FullName = "US Dollar" });
            }

            if (!context.Set<Setting>().Any())
            {
                context.Set<Setting>().AddOrUpdate(new Setting { DefaultCurrencyId = 1 });
            }

            context.SaveChanges();
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultCurrencyRates(ShopContext context)
        {
            if (!context.Set<CurrencyRate>().Any())
            {
                context.Set<CurrencyRate>()
                    .AddOrUpdate(new CurrencyRate { CurrencyId = 2, TargetCurrencyId = 1, CrossCourse = 1.2M });

                context.Set<CurrencyRate>()
                    .AddOrUpdate(new CurrencyRate { CurrencyId = 1, TargetCurrencyId = 2, CrossCourse = 0.9M });
            }

            context.SaveChanges();
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultGenres(ShopContext context)
        {
            if (!context.Set<Genre>().Any())
            {
                // source: https://en.wikipedia.org/wiki/List_of_popular_music_genres
                context.Set<Genre>()
                    .AddOrUpdate(
                        new Genre { Name = "Unknown" },
                        new Genre
                        {
                            Name = "Blues",
                            Description =
                                    @"Блюз (от англ. Blues или Blue Devils — тоска, печаль) — музыкальная форма и музыкальный жанр, зародившиеся в конце XIX века в афроамериканском сообществе Юго-востока США, в среде выходцев с плантаций «Хлопкового пояса». Является (наряду с рэгтаймом, ранним джазом, хип-хопом и др.) одним из наиболее значимых вкладов афроамериканцев в мировую музыкальную культуру[источник не указан 1601 день]. Впервые термин использовал Джордж Колман в одноактном фарсе «Blue Devils» (1798)[1]. С тех пор в литературных произведениях фразу англ. «Blue Devils» часто используют для описания подавленного настроения[2]. Блюз сложился из таких её проявлений, как «рабочая песня», холлер (ритмичные выкрики, сопровождавшие работу в поле), выкрики в ритуалах африканских религиозных культов (англ. (ring) shout), спиричуэлс (христианские песнопения), шант и баллады (короткие стихотворные истории). Во многом повлиял на современную популярную музыку, в особенности таких жанров как «поп», «джаз», «рок-н-ролл» «соул». Преобладающая форма блюза — 12 тактов, где первые 4 такта зачастую играются на тонической гармонии, по 2 — на субдоминанте и тонике и по 2 — на доминанте и тонике. Это чередование также известно как «блюзовая сетка». Метрическая основа в блюзе — 4/4. Нередко используется ритм восьмых триолей с паузой — так называемый шаффл. Характерной особенностью блюза является использование блюзового лада, включающего в себя пониженные III, V и VII ступени (т. н. «блюзовые ноты»). Часто музыка строится по структуре «вопрос — ответ» (англ.), выраженная как в лирическом наполнении композиции, так и в музыкальном, зачастую построенном на диалоге инструментов между собой. Блюз является импровизационной формой музыкального жанра, где в композициях зачастую используют только основной опорный «каркас», который обыгрывают солирующие инструменты. Исконная блюзовая тематика строится на чувственной социальной составляющей жизни афроамериканского населения, его трудностях и препятствиях, возникающих на пути каждого темнокожего человека. "
                        },
                        new Genre
                        {
                            Name = "Country",
                            Description =
                                    "Ка́нтри, ка́нтри-музыка (от англ. country music — сельская музыка) — обобщённое название формы музицирования, возникшей среди белого населения сельских районов юга и запада США. Кантри основано на песенных и танцевальных мелодиях, завезённых в Америку ранними переселенцами из Европы, и опирается на англо-кельтские народные музыкальные традиции. Эта музыка долгое время сохранялась в почти нетронутом виде среди жителей горных районов штатов Теннесси, Кентукки, Северная Каролина. По своему содержанию песни и баллады, исполняемые кантри-исполнителями, близки к обычной для сельского фольклора тематике. Дух искусства кантри определяется также подбором струнных инструментов, как гитара и мандолина. С самого начала, характерный колорит звучанию музыки придавала скрипка-фиддл — основной музыкальный инструмент американских фермеров на протяжении нескольких веков. На стиль кантри также повлияла негритянская музыкальная культура. Это яснее всего проявляется в ритмике и непринуждённо-импровизационной манере исполнения, а также в использовании таких инструментов, как банджо и губная гармоника. Кантри-музыка имеет тенденцию к открытым гитарным аккордам и ритмом 2/4 или 4/4. Форма вокальных номеров обычно куплетная — сольный запев и хоровой рефрен. "
                        },
                        new Genre
                        {
                            Name = "Electronic",
                            Description =
                                    "Электро́нная му́зыка (нем. elektronische Musik, англ. electronic music) — музыка, созданная с использованием электромузыкальных инструментов и электронных технологий (с последних десятилетий XX века — компьютерных технологий). Как специфическое направление в мире музыки электронная музыка оформилась во второй половине XX века и к началу XXI века широко распространилась в академической и массовой культуре. Электронная музыка оперирует звуками, которые способны издавать электронные и электромеханические музыкальные инструменты, а также звуками, возникающими при помощи электрических / электронных устройств и различного рода преобразователей (магнитофоны, генераторы, компьютерные звуковые карты, звукосниматели и т.п.), которые в строгом смысле не являются музыкальными инструментами. До последней трети XX века электронная музыка ассоциировалась, главным образом, с экспериментами (как в России, так и за рубежом) в академической музыке, но это положение дел изменилось с налаживанием серийного производства синтезаторов звука в 1970-е гг. Синтезаторы благодаря своей умеренной стоимости стали доступны широкой публике. Это изменило образ популярной музыки — синтезаторы стали использовать многие джазовые, рок- и поп-музыканты. В начале XXI века электронная музыка включает в себя широкий спектр стилей и жанров — от единичных экспериментов авангардистов до широко тиражируемой прикладной музыки. "
                        },
                        new Genre
                        {
                            Name = "Folk",
                            Description =
                                    "Как самостоятельный жанр фолк-музыка оформилась в конце 50-х — начале 60-х годов, когда ритмические приёмы, получившие распространение в поп-музыке, стали использовать для аранжировки народных мелодий. Одним из первых известных исполнителей фолк-рока стал американский певец и композитор Боб Дилан. Наивысшая популярность фолк-рока пришлась на середину 60-х, когда на эстраде появились такие авторы и исполнители как Ричи Хейвенс, Джони Митчелл, Мелани, а также самые разные группы, использовавшие в своих композициях элементы народной музыки. Классическим примером такой музыки может служить песня Пола Саймонда и Артура Гарфанкела «El Condor Pasa»[3]. Характерным для фолк-рока был также социальный подтекст песен. В конце 50-х — начале 60-х годов XX века в США возник и распространился т.н. стиль Фолк-ривайвл (от англ. folk revival «народное возрождение») — музыкальный стиль в рок-музыке, основанный на народных песнях и имеющий яркое выраженную гражданскую направленность[5]. В течение короткого периода (ок. 1958—1965 гг.) «народная музыка» занимала высокие места в музыкальных поп-чартах США и Британии. Хиты были в основном созданы музыкантами-профессионалами или полупрофессионалами (а не «народом»), и часто просто в народном стиле (англ. watereddown). Тем не менее, «народное возрождение» оказало глубокое влияние на будущее поп-музыки и кантри-стиля. "
                        },
                        new Genre
                        {
                            Name = "Hip hop",
                            Description =
                                    "Хип-хоп (англ. Hip-hop) — музыкальный жанр. Хип-хоп имеет большое количество направлений: от достаточно «лёгких» стилей, таких как поп-рэп, до агрессивных — хардкор-рэп, хорроркор. Содержание песен варьируется от лёгкого и непринуждённого, вроде воспоминаний о «старых добрых временах», ролл до поднятия социальных проблем. Истоки хип-хопа лежат в фанке, который является главным «прародителем» этого направления. Однако влияние на становление хип-хопа оказали и другие жанры — ритм-н-блюз, соул, джаз, рок, регги.Очень часто термины «хип-хоп» и «рэп» используются как синонимы, что не является правильным. Рэп — «речитативное исполнение стихов под ритмическую музыку»[1], которое может использоваться не только хип-хоп исполнителями, но и представителями других жанров — современного ритм-н-блюза, поп-музыки, рэпкора, ню-метала, раггамаффина; в то же время существуют исполнители альтернативного хип-хопа, не использующие в своих записях вокал. Возникнув как разновидность стиля spoken word, рэп превратился в настоящее искусство, имеющее множество граней. Так, рэперы Twista и Busta Rhymes исполняют сверхскоростной речитатив, а Ghostface Killah превращает свои рифмы в настоящие загадки, непонятные неподготовленному слушателю. Термин «хип-хоп» определяют как сочетание двух слов — «hip» (ура) и «hop» (прыжок)[2]. Или как аналог словосочетания на русском языке — «Прыг-Скок» (армейский счёт при маршировке в американских вооруженных силах) "
                        },
                        new Genre { Name = "Jazz" },
                        new Genre { Name = "Latin" },
                        new Genre { Name = "Latin house" },
                        new Genre { Name = "Pop" },
                        new Genre { Name = "Disco" },
                        new Genre { Name = "Rock" },
                        new Genre { Name = "New age" },
                        new Genre { Name = "Metall" },
                        new Genre { Name = "Trash metall" },
                        new Genre { Name = "Heavy metall" },
                        new Genre { Name = "R&B and soul" },
                        new Genre { Name = "Rap" },
                        new Genre { Name = "Rap" },
                        new Genre { Name = "Hip-hop" },
                        new Genre { Name = "Jazz" },
                        new Genre { Name = "House" },
                        new Genre { Name = "Deep house" },
                        new Genre { Name = "Trance" },
                        new Genre { Name = "Ambient" },
                        new Genre { Name = "Chillout" },
                        new Genre { Name = "Speed garage" },
                        new Genre { Name = "Breakbit" },
                        new Genre { Name = "Breaks" },
                        new Genre { Name = "Drum `n` Bass" },
                        new Genre { Name = "Dubstep" },
                        new Genre { Name = "Trip hop" });
                context.SaveChanges();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultPriceLevels(ShopContext context)
        {
            if (!context.Set<PriceLevel>().Any())
            {
                context.Set<PriceLevel>().AddOrUpdate(new PriceLevel { Name = "Default" });
                context.SaveChanges();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultTracks(ShopContext context)
        {
            if (!context.Set<Track>().Any())
            {
                context.Set<Track>()
                    .AddOrUpdate(
                        new Track { ArtistId = 1, Name = "Море", GenreId = 10, OwnerId = 104 },
                        new Track { ArtistId = 1, Name = "Крыша дома твоего", GenreId = 10, OwnerId = 104 },
                        new Track { ArtistId = 2, Name = "Песня о тревожной молодости", GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Just be", ArtistId = 5, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Adagio for strings", ArtistId = 5, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Traffic", ArtistId = 5, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Fligth 643", ArtistId = 5, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Dance for life", ArtistId = 5, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Breda 8pm", ArtistId = 5, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Music", ArtistId = 4, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Umbrella", ArtistId = 4, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Work", ArtistId = 4, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Rude boy", ArtistId = 4, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "S&M", ArtistId = 4, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Kiss it better", ArtistId = 4, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Disturbia", ArtistId = 4, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Love me like you do", ArtistId = 8, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Your song", ArtistId = 8, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Lights", ArtistId = 8, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "TKO", ArtistId = 14, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Hair up", ArtistId = 14, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "My love", ArtistId = 14, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Mercy", ArtistId = 15, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Ruin", ArtistId = 15, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Imagination", ArtistId = 15, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Alejandro", ArtistId = 16, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Paparazzi", ArtistId = 16, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Just dance", ArtistId = 16, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Shape of my heart", ArtistId = 17, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Fields of gold", ArtistId = 17, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Fragile", ArtistId = 17, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Enter sandman", ArtistId = 18, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "The unforgiven", ArtistId = 18, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Fade to black", ArtistId = 18, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "One", ArtistId = 18, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Hardwired", ArtistId = 18, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Until it sleeps", ArtistId = 18, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Enter sandman", ArtistId = 18, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Mama said", ArtistId = 18, GenreId = 24, OwnerId = 104 },
                        new Track { Name = "Englishman in New York", ArtistId = 17, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Orbion", ArtistId = 19, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Intence", ArtistId = 19, GenreId = 10, OwnerId = 104 },
                        new Track { Name = "Freefall", ArtistId = 19, GenreId = 10, OwnerId = 104 });
                context.SaveChanges();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="context">
        ///     The context.
        /// </param>
        private void AddDefaultTracksPrices(ShopContext context)
        {
            if (!context.Set<TrackPrice>().Any())
            {
                context.Set<TrackPrice>()
                    .AddOrUpdate(
                        new TrackPrice { TrackId = 1, CurrencyId = 1, Price = 4.99m, PriceLevelId = 1 },
                        new TrackPrice { TrackId = 2, CurrencyId = 1, Price = 4.98m, PriceLevelId = 1 });
                context.SaveChanges();
            }
        }

        private void AddDefaultUsers(ShopContext context)
        {
            if (!context.Set<User>().Any())
            {
                context.Set<User>()
                    .AddOrUpdate(
                        new[]
                            {
                               new User{
                                        FirstName = "Lucy",
                                        LastName = "Newman",
                                        Email = "Lucy.NEWM7632@mail2web.com",
                                        Login = "lunewman7617",
                                        Password = "9D40E02DF18047E7E2E939D41F115538618DABA3",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(559) 302-512612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("1.9.1976", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Amy",
                                        LastName = "Rivas",
                                        Email = "A.RIV3294@hushmail.com",
                                        Login = "amri6192",
                                        Password = "462156D34A58FEFFA2E7898D2E957F4829958CCF",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(872) 543-189712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("26.10.1989", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Randall",
                                        LastName = "Bridges",
                                        Email = "Randa.BRI6673@gmail.com",
                                        Login = "randallbri8552",
                                        Password = "D8685BAE08FAE44674398F1295E2B6DD1000ED2C",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(229) 646-968012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("14.7.1996", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Bridger",
                                        LastName = "Hayes",
                                        Email = "Bridger.HAYES3120@mail2web.com",
                                        Login = "bridhay4912",
                                        Password = "BBD073E98D23D47A2C8D30F714C94E127A6B5598",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(256) 571-838512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("6.11.1993", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Ansley",
                                        LastName = "Reed",
                                        Email = "Ansley.RE5375@yahoo.com",
                                        Login = "ansre4082",
                                        Password = "B71885A2DEF63C285823025E443E41D6C3923417",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(916) 504-019912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("10.3.1976", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Brennen",
                                        LastName = "Hammond",
                                        Email = "Brenne.HAM8704@hushmail.com",
                                        Login = "brennenham6680",
                                        Password = "02780744136A9AF73F2932887B5C0328AFAEA5BA",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(216) 244-159412",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("2.8.1986", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Kolton",
                                        LastName = "Humphrey",
                                        Email = "Kol.HUMP6010@live.com",
                                        Login = "kolthumph1261",
                                        Password = "AD59769F0342B79BA55E164F690A855F1866D323",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(312) 828-681512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("14.11.1997", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Shawn",
                                        LastName = "Hester",
                                        Email = "Sha.HESTER7451@gmail.com",
                                        Login = "shahester1871",
                                        Password = "5644705DE35866C155801653230E5E1A79308856",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(434) 968-062412",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("20.10.1998", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Luke",
                                        LastName = "Church",
                                        Email = "Luke.CHURC2472@gmail.com",
                                        Login = "lukchur6739",
                                        Password = "FDBDEFA65D8E5AA4EFBBEABCD410902CF5809A70",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(828) 872-803112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("7.10.1992", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Chris",
                                        LastName = "Glover",
                                        Email = "Chri.GLOVER8922@hushmail.com",
                                        Login = "chglover7812",
                                        Password = "C268BF6DB178101A6DD7A0A1BD88D8D3D58E62CA",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(614) 818-042412",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("9.1.1971", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Zavier",
                                        LastName = "Chapman",
                                        Email = "Zavi.CHAPM8958@gmail.com",
                                        Login = "zavichapm2283",
                                        Password = "3BE142E8C94FA80DA77DB9E10A086B7DC5B9AB14",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(231) 129-735912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("23.11.1980", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Lennox",
                                        LastName = "Wolf",
                                        Email = "Len.WO6341@yahoo.com",
                                        Login = "lenwolf7991",
                                        Password = "3A7A2B4B2210AF76F6D2A95F81389097DC8B17D1",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(952) 668-140112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("3.11.1985", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Joel",
                                        LastName = "Bentley",
                                        Email = "Jo.BENTL3269@yahoo.com",
                                        Login = "joebentley2505",
                                        Password = "DE971109E69BA285987A14DE98F932B83EA6181C",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(732) 808-631512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("15.11.1977", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Jagger",
                                        LastName = "Curry",
                                        Email = "Jag.CU8065@mail2web.com",
                                        Login = "jaggercurr8007",
                                        Password = "8C1C9F8E7CB8313D499B254CA7FE155895ACD35F",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(432) 906-558212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("15.2.1994", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Raelynn",
                                        LastName = "Ayala",
                                        Email = "Raely.AYALA6313@hushmail.com",
                                        Login = "raelynayala550",
                                        Password = "4B70410A7760752694806EB813EAC25B3FB17CCF",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(313) 422-609712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("21.10.1991", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Kolten",
                                        LastName = "Fuentes",
                                        Email = "Kolte.FUENTE4895@yahoo.com",
                                        Login = "koltefuent9338",
                                        Password = "87866A3C04CB4075C214B1B8FFAAA81E5EBE0584",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(684) 783-543112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("13.6.1979", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Tyrese",
                                        LastName = "Alvarez",
                                        Email = "Tyrese.ALVAR7497@mail2web.com",
                                        Login = "tyresealvar996",
                                        Password = "03B0489191255F5361CE606D4C250A498E6D646E",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(253) 432-655112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("13.7.1995", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Jonas",
                                        LastName = "Reid",
                                        Email = "Jonas.REID8439@live.com",
                                        Login = "jorei8636",
                                        Password = "57E330E5307257BD130FAB9D658A48B228B7760F",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(310) 296-476812",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("19.3.1991", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Zane",
                                        LastName = "Bray",
                                        Email = "Zan.BRA5633@yahoo.com",
                                        Login = "zanbray3595",
                                        Password = "82DE003A674FBFA57ACCF4D7F360147A30DE4E9F",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(805) 197-464612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("25.1.1997", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Arielle",
                                        LastName = "Sawyer",
                                        Email = "Ariel.SAWY8081@mail2web.com",
                                        Login = "arisawyer3158",
                                        Password = "1517D20DF090DB72F758B97B94E7C0C56A4F9A08",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(703) 411-895612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("18.4.1994", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Israel",
                                        LastName = "Lamb",
                                        Email = "Isra.LAM6564@hushmail.com",
                                        Login = "israelamb8125",
                                        Password = "768E9985DA7A126E0DD3DBE14268CC19F0F8EC8D",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(442) 407-686812",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("5.3.1995", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Zain",
                                        LastName = "Sparks",
                                        Email = "Za.SPARKS8559@hushmail.com",
                                        Login = "zaispa6086",
                                        Password = "4D6E08F2FC4D251A381672F2D87C214B387D29EC",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(651) 451-877312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("3.11.1979", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Luz",
                                        LastName = "Rowe",
                                        Email = "L.RO8814@hushmail.com",
                                        Login = "luzro3209",
                                        Password = "1FA3B20DEB0F859DAF86835FA03AE0CF909FC47A",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(719) 952-531512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("8.8.1978", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Zion",
                                        LastName = "Hull",
                                        Email = "Zio.HUL9855@gmail.com",
                                        Login = "zionhul7455",
                                        Password = "2555CBB2E6AD9F9250121DEA6DCF35D6943F4D22",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(954) 281-156812",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("27.7.1979", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Deven",
                                        LastName = "Maddox",
                                        Email = "Deven.MADD8080@live.com",
                                        Login = "devenmadd3132",
                                        Password = "903C2383BCFDBDA8BA353C06C6E44CCDED5A7872",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(585) 939-270912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("25.9.1984", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Samson",
                                        LastName = "Witt",
                                        Email = "Sam.WITT2872@yahoo.com",
                                        Login = "samsonwit6692",
                                        Password = "C949E24F039E1E4EC50A0ED476DBB51CDDF102D8",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(248) 367-767212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("17.2.1986", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Charlie",
                                        LastName = "Contreras",
                                        Email = "Charl.CONT3430@live.com",
                                        Login = "charcontre4583",
                                        Password = "7F4B3B33AB286CCF65F52ED02D6EA5A0F147CEB8",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(727) 304-062112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("23.5.1978", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Jaylynn",
                                        LastName = "Little",
                                        Email = "Jay.LITT1396@gmail.com",
                                        Login = "jaylylittle908",
                                        Password = "C85BF8C007FB474B8FD47B72653FCA7BACC69E7A",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(828) 310-025312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("21.11.1978", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Emilie",
                                        LastName = "Harrison",
                                        Email = "Emil.HARRISON2206@hushmail.com",
                                        Login = "emilieharrison",
                                        Password = "A61DFBEFA9C99BAFADB8D22B8D7118F32B50E721",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(208) 484-014512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("23.10.1977", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Vihaan",
                                        LastName = "Snyder",
                                        Email = "Vihaa.SNY2374@hushmail.com",
                                        Login = "vihsny3651",
                                        Password = "68F13943838884BC192CF6D45876B7E8FCAD1675",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(731) 668-004812",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("19.6.1980", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Preston",
                                        LastName = "Bryant",
                                        Email = "Pre.BRY7126@live.com",
                                        Login = "prestbryant885",
                                        Password = "DB6C1C97A6B9739112C9EC0E2A1D615ACC1D9404",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(804) 274-619612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("18.10.1985", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Angeline",
                                        LastName = "Burton",
                                        Email = "Angeline.BURT7420@live.com",
                                        Login = "angelibur3952",
                                        Password = "29CF10899F89CA32DF497B84C205F35FCAD35091",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(901) 298-371412",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("22.6.1997", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Liliana",
                                        LastName = "French",
                                        Email = "Lil.FRE3510@hushmail.com",
                                        Login = "lilianafrenc51",
                                        Password = "243D7C788706C30F98D3CE3A4163A742E31156B8",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(319) 368-593512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("5.1.1971", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Melany",
                                        LastName = "Ratliff",
                                        Email = "Mel.RATLI9465@mail2web.com",
                                        Login = "melratl8339",
                                        Password = "658F25D120ED51B0F3477FFEE7A95404C246053D",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(816) 678-897612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("10.8.1981", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Monica",
                                        LastName = "Pope",
                                        Email = "Mon.PO2187@gmail.com",
                                        Login = "monipo3924",
                                        Password = "8AEC4773FB5DBC6C41C97455584595CABE4570A9",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(432) 792-537212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("19.2.1987", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Ansley",
                                        LastName = "Molina",
                                        Email = "Ansl.MOL6315@live.com",
                                        Login = "anslmolin2696",
                                        Password = "EB580EEB23065C584B23005CEE47E50F3385BEAB",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(682) 256-561412",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("9.4.1974", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Carmelo",
                                        LastName = "Valencia",
                                        Email = "Carmel.VALENCIA6645@hushmail.com",
                                        Login = "carmevalenci90",
                                        Password = "2B80DB86A92DDD38D0F46A0A69659B04C3160C6D",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(803) 862-704112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("25.10.1997", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Kaelynn",
                                        LastName = "Dawson",
                                        Email = "Kaelyn.DAWSO1809@yahoo.com",
                                        Login = "kaelyndaws5236",
                                        Password = "12906A2790B903D2067E4412C18E84314DF1E8F5",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(317) 667-176012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("14.10.1992", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Krish",
                                        LastName = "Maynard",
                                        Email = "Krish.MAYNARD4522@hushmail.com",
                                        Login = "krishmaynard26",
                                        Password = "34BC906ABCFF203CA09EA4F466B5EB817CAEB2A8",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(786) 981-474612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("12.1.1973", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Raegan",
                                        LastName = "Espinoza",
                                        Email = "Rae.ESPINOZ1158@hushmail.com",
                                        Login = "raegaespinoza8",
                                        Password = "83926DD4722D759CE9F493E50E4AC128168DDDC5",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(276) 364-008512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("4.7.1985", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Layton",
                                        LastName = "Roman",
                                        Email = "Layto.ROMAN8340@yahoo.com",
                                        Login = "layroma2879",
                                        Password = "54993445325C1B87F93D2E00EC5C1D9D0A2541C6",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(615) 228-921612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("20.6.1987", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Crosby",
                                        LastName = "Lowe",
                                        Email = "Cros.LO8763@gmail.com",
                                        Login = "croslowe2437",
                                        Password = "7BA36DDCCA550735FC96B464E36822C884548CA6",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(551) 433-878212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("1.9.1993", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Lena",
                                        LastName = "Keith",
                                        Email = "Lena.KEIT8127@mail2web.com",
                                        Login = "lenakeit6440",
                                        Password = "D64CE902641AA396DE01374AC3E4F47AA9BC853E",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(539) 882-007012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("15.2.1985", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Turner",
                                        LastName = "Sellers",
                                        Email = "Turn.SELLER4149@hushmail.com",
                                        Login = "turneseller197",
                                        Password = "3F32A7645E190DD2F7BA88D4FD3B844144E981CC",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(458) 423-149712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("20.9.1994", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Lillie",
                                        LastName = "Mack",
                                        Email = "Lil.MA4185@yahoo.com",
                                        Login = "lillimac5541",
                                        Password = "6B215E4981322BB6311DAB7D773C6F9F84B3D0F1",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(765) 430-023812",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("4.3.1985", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Turner",
                                        LastName = "Sullivan",
                                        Email = "Turne.SULLIV7308@hushmail.com",
                                        Login = "tursullivan686",
                                        Password = "775DB3693DE4F626A4D7806797E2D58996494ACE",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(865) 277-222412",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("15.5.1989", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Braylon",
                                        LastName = "Beck",
                                        Email = "Braylon.BE5466@mail2web.com",
                                        Login = "braylbe6464",
                                        Password = "C7D508C8CBB5E32DA3D686CA183ACF534941F1D9",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(626) 548-942912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("25.2.1986", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Santino",
                                        LastName = "Cummings",
                                        Email = "Santi.CUMMIN4063@hushmail.com",
                                        Login = "santincumming7",
                                        Password = "BD00485C8F06A4532DC3B362B5965BA04B87DDB3",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(517) 516-028212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("6.8.1979", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Lilia",
                                        LastName = "Burch",
                                        Email = "Lilia.BURCH8421@live.com",
                                        Login = "lilburch1327",
                                        Password = "C9B8B6D7637F71CCE20C87335C945CA57371502D",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(910) 540-065012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("10.11.1999", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "London",
                                        LastName = "Emerson",
                                        Email = "London.EMERSO9825@hushmail.com",
                                        Login = "londoeme3609",
                                        Password = "DE7D735617E4CC11BC7ADD1074431B04AAC33541",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(956) 171-330612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("17.2.1986", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Joey",
                                        LastName = "Bradshaw",
                                        Email = "Jo.BRAD9503@mail2web.com",
                                        Login = "jobrads3096",
                                        Password = "43792721864D83618A00FCFDF73953FEC7B307EE",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(251) 214-980912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("25.5.1996", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Arturo",
                                        LastName = "Morrow",
                                        Email = "Art.MORRO7437@live.com",
                                        Login = "artumorr6001",
                                        Password = "CB541EACB4B05AA1A83FE96C3E8B2431C63F2E00",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(513) 956-977112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("5.3.1980", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Braylee",
                                        LastName = "Dennis",
                                        Email = "Braylee.DENNIS9102@live.com",
                                        Login = "braydenni8376",
                                        Password = "5262BF67CB268E8FF9828D9EB9903456CF1D5F21",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(830) 235-072212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("5.3.1980", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Khloe",
                                        LastName = "Brady",
                                        Email = "Khl.BRADY8409@mail2web.com",
                                        Login = "khlbrad1771",
                                        Password = "430CD3C406EECFA5942814FFA83C2EBCFE13EA49",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(949) 715-316712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("4.1.1982", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Sonia",
                                        LastName = "Spears",
                                        Email = "So.SPE1519@hushmail.com",
                                        Login = "sospears5641",
                                        Password = "32FBA45E5DCD97BCF64ADD808F788AE7553CC90E",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(432) 154-712812",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("19.7.1999", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Renee",
                                        LastName = "Parker",
                                        Email = "Re.PARKE7585@gmail.com",
                                        Login = "repark3071",
                                        Password = "D0DCFF7D8A4102657DF9FB14EEDA979068171825",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(425) 519-846012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("6.8.1994", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Leonard",
                                        LastName = "Stokes",
                                        Email = "Leo.STOKE3947@live.com",
                                        Login = "leostoke9830",
                                        Password = "9D275A9D8E23187BBCF9D41F9E274570EECC909D",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(574) 128-639212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("7.6.1998", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Sylvia",
                                        LastName = "Norris",
                                        Email = "Syl.NORRI7128@mail2web.com",
                                        Login = "sylvianorr5131",
                                        Password = "6BA20EFD393188B2602C299B0DB695DF3CE849CF",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(607) 945-079612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("18.2.1982", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Madelynn",
                                        LastName = "Roth",
                                        Email = "Madel.RO1086@live.com",
                                        Login = "maderot4064",
                                        Password = "D64CCE81E42686BA0BC45184A448C6BFF51B7FE2",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(920) 542-283612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("4.11.1989", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Virginia",
                                        LastName = "Perry",
                                        Email = "Virgi.PERRY6471@mail2web.com",
                                        Login = "virginiperr528",
                                        Password = "7A2426130F697A4E233BE1E903F9BA6B95D3D4AD",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(252) 529-878712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("23.11.1983", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Louis",
                                        LastName = "Douglas",
                                        Email = "Lou.DOUG2533@mail2web.com",
                                        Login = "loudou1484",
                                        Password = "62542C52831BC3667A934E5BD6DC50F390B1444F",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(630) 447-210112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("27.7.1970", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Blakely",
                                        LastName = "Morales",
                                        Email = "Blakely.MORAL6277@hushmail.com",
                                        Login = "blakemorales44",
                                        Password = "DA0654977BF314B014353FF21B3BAC2A4CFCFBD9",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(518) 614-271912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("17.11.1984", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Phoebe",
                                        LastName = "Reid",
                                        Email = "Phoe.REI2270@gmail.com",
                                        Login = "phoebreid6853",
                                        Password = "FE2D73B76E1139D60809DE645075C1E8A249F424",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(260) 551-653012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("17.2.1994", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Presley",
                                        LastName = "Ellison",
                                        Email = "Pres.ELLI2740@hushmail.com",
                                        Login = "presleyellison",
                                        Password = "EE4ADABDED66CF2AAC7DBB9C3AB7E9A0F8851405",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(574) 351-787312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("11.1.1983", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Rivka",
                                        LastName = "Mcdowell",
                                        Email = "Rivka.MCDOW2475@hushmail.com",
                                        Login = "rivmcdow6221",
                                        Password = "0CA17718835CF9B8CF0DD0781A6D2679C895EFC5",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(636) 837-856512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("18.1.1974", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Matias",
                                        LastName = "Holland",
                                        Email = "Mat.HOLLA4405@live.com",
                                        Login = "matiashollan64",
                                        Password = "99C258F135C004D44E2CFB40FF99F106B1371FB6",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(206) 358-915112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("25.3.1970", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Kaylyn",
                                        LastName = "Hancock",
                                        Email = "Kaylyn.HANCOC1797@gmail.com",
                                        Login = "kaylhan6775",
                                        Password = "7BB968526BB41D1DF289B5E220EA868369DFA2EB",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(865) 283-820812",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("16.9.1986", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Michaela",
                                        LastName = "Howard",
                                        Email = "Micha.HOWAR7077@live.com",
                                        Login = "michaehoward20",
                                        Password = "BD0C159C160FFE5C021DBD505E96AB9B39CBB79F",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(559) 824-294412",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("22.10.1998", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Roman",
                                        LastName = "Wagner",
                                        Email = "Rom.WAGNE3232@gmail.com",
                                        Login = "romanwag3392",
                                        Password = "481C7694944A97891B60F58302E3EDBE76A86056",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(504) 520-428312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("16.5.1991", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Jaylyn",
                                        LastName = "Cortez",
                                        Email = "Jaylyn.CORTEZ5145@gmail.com",
                                        Login = "jaycortez4800",
                                        Password = "5CA743EE30BB68CD5AC1EB813983D404CAC39D00",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(917) 488-020912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("10.2.1991", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Kaylen",
                                        LastName = "Mcleod",
                                        Email = "Kaylen.MCLEO6387@live.com",
                                        Login = "kaylemcleo2855",
                                        Password = "EC71F56F9E6067B7B36D2C870EE8F29BE55AF2A7",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(660) 188-489912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("3.4.1997", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Aliyah",
                                        LastName = "Gonzales",
                                        Email = "Aliyah.GONZALE5360@gmail.com",
                                        Login = "aliyahgonzale8",
                                        Password = "A00A691E0BD55DCDEF7FB65F5F42FEE61B22FD52",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(325) 703-216012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("27.8.1983", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Rene",
                                        LastName = "Finley",
                                        Email = "Ren.FINLE3307@gmail.com",
                                        Login = "refin3034",
                                        Password = "32B1464EF3CE241CB00E80A94045545B75FA6D1E",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(309) 644-548512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("3.11.1987", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Laney",
                                        LastName = "Frye",
                                        Email = "Lane.FRYE1785@live.com",
                                        Login = "lafry3283",
                                        Password = "052462375F2AA7DC84275E5214A49570BF0B4113",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(406) 622-715012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("8.1.1978", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Jackson",
                                        LastName = "Dejesus",
                                        Email = "Jacks.DEJ8583@yahoo.com",
                                        Login = "jackdejes7933",
                                        Password = "164C3AE05E68504A0228166C58FEC96BADD45FA1",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(970) 612-212612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("16.8.1989", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Kylie",
                                        LastName = "Cook",
                                        Email = "Kyli.CO5361@live.com",
                                        Login = "kylicook4655",
                                        Password = "D4C02B5BA02D89FA86D12D1CA2B3967A6A0D12CE",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(339) 276-872612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("26.2.1982", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Rivka",
                                        LastName = "Rowland",
                                        Email = "Rivka.ROWLA7037@mail2web.com",
                                        Login = "rivkrowlan4499",
                                        Password = "35BE04BCD29A3DAA763CBCEE6E8421C9958A5DC9",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(412) 345-795112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("8.7.1979", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Semaj",
                                        LastName = "Robbins",
                                        Email = "Sem.ROB5290@gmail.com",
                                        Login = "serob7528",
                                        Password = "AA1C012EC950C4FD80F5A31C7186147749B49EF4",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(410) 349-393312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("13.2.1983", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Arely",
                                        LastName = "Phelps",
                                        Email = "Ar.PHELP3209@live.com",
                                        Login = "arephelp1098",
                                        Password = "2B3266B1F3C7396648F2D50879757FBEA2E48D7E",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(320) 327-095712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("25.8.1990", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Charlie",
                                        LastName = "Hoover",
                                        Email = "Charli.HOO1318@mail2web.com",
                                        Login = "charhoov6215",
                                        Password = "7F710F97DAC20F7974239CAFD4286E91CAE087F0",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(325) 118-301612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("22.7.1975", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Ariana",
                                        LastName = "Holland",
                                        Email = "Ariana.HOLLAN8232@live.com",
                                        Login = "arianhol4044",
                                        Password = "87EC3A400B16119017DFE62DD0F1644AE2F8BE39",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(732) 197-873012",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("24.11.1992", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Edith",
                                        LastName = "Mcmahon",
                                        Email = "Edith.MCMAHON5269@hushmail.com",
                                        Login = "edimcmah7262",
                                        Password = "FEB174ADB373F4666184AFAFCBA5887B19009177",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(239) 694-107712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("21.5.1992", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Sergio",
                                        LastName = "Curtis",
                                        Email = "Serg.CURTI3319@live.com",
                                        Login = "sergicurtis513",
                                        Password = "DD35A3E33E802059E095CDB228997842911772BF",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(939) 453-210512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("16.10.1973", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Temperance",
                                        LastName = "Lowery",
                                        Email = "Tempe.LOW5437@mail2web.com",
                                        Login = "tempelower7098",
                                        Password = "8460036AC5A5D0426FEB0BEC531FA5182911D46D",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(207) 186-745512",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("16.7.1986", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Wyatt",
                                        LastName = "Wong",
                                        Email = "Wya.WO4057@mail2web.com",
                                        Login = "wyawon1238",
                                        Password = "D35541CE6B58DBD46E847211EDCD10BA990ECAA1",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(228) 769-002112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("27.2.1981", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Skylar",
                                        LastName = "Stewart",
                                        Email = "Sky.STEW6239@yahoo.com",
                                        Login = "skylstewart643",
                                        Password = "85C09C2CE5F654977BA9168E3B524572BBAE53D6",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(334) 812-228312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("6.11.1980", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Damarion",
                                        LastName = "Warren",
                                        Email = "Damarion.WARREN3550@live.com",
                                        Login = "damarwarren485",
                                        Password = "B2DB010444186340599D19EFC347DE7F2A3EF422",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(218) 431-653912",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("19.1.1984", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Gia",
                                        LastName = "Solomon",
                                        Email = "G.SOLO2457@live.com",
                                        Login = "giasolo3919",
                                        Password = "1C2F8C2D3EE30AF036EB7E698FB4398866057E3A",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(408) 687-840712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("16.7.1973", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Carleigh",
                                        LastName = "Delgado",
                                        Email = "Carlei.DELGAD9220@gmail.com",
                                        Login = "carldelgad3092",
                                        Password = "A5A87538F7180EC42E2617424DB61DA6CD6ED6F7",
                                        Sex = "M",
                                        CountryId = 2,
                                        PhoneNumber = "(931) 271-959112",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("27.8.1997", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Sophie",
                                        LastName = "Zamora",
                                        Email = "Sophi.ZAM8845@live.com",
                                        Login = "sophiezam6682",
                                        Password = "71D9538B2D57DE5551472A5B0CFA6F601ED213F8",
                                        Sex = "M",
                                        CountryId = 4,
                                        PhoneNumber = "(850) 909-818212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("5.11.1978", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Jagger",
                                        LastName = "Perez",
                                        Email = "Jagge.PE7617@mail2web.com",
                                        Login = "jaggpere5958",
                                        Password = "E132924DEE02E4C3FB34336C1B411259B8291DF7",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(831) 334-298212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("26.7.1994", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Masen",
                                        LastName = "Hodge",
                                        Email = "Masen.HODG1687@gmail.com",
                                        Login = "mahodg9727",
                                        Password = "711AE724631B4FD034E0747D73982ED8CAB9E442",
                                        Sex = "F",
                                        CountryId = 1,
                                        PhoneNumber = "(858) 740-330612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("14.5.1987", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Alena",
                                        LastName = "James",
                                        Email = "Alena.JA4906@mail2web.com",
                                        Login = "alejames6804",
                                        Password = "711A904EAB5DD7785261F3FB433144C9E84E701A",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(712) 332-111312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("9.2.1971", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Kennedy",
                                        LastName = "Potter",
                                        Email = "Ken.POTTER2880@hushmail.com",
                                        Login = "kenpott6578",
                                        Password = "F19909712E7062662978A5EDD4971FD78586D3EB",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(903) 511-128712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("15.11.1988", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Lucille",
                                        LastName = "Oneal",
                                        Email = "Lucill.ONEA3748@hushmail.com",
                                        Login = "lucioneal9464",
                                        Password = "04A6AEB2115B9A56DC0F66967D468C205DD9C9C3",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(636) 296-546212",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("14.5.1991", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Ezekiel",
                                        LastName = "Santos",
                                        Email = "Ezekie.SANT5762@yahoo.com",
                                        Login = "ezekiesantos29",
                                        Password = "71656C2062D92DBD37E8CB9C5799F479E204963A",
                                        Sex = "F",
                                        CountryId = 3,
                                        PhoneNumber = "(747) 176-908612",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("17.2.1991", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Finley",
                                        LastName = "Trujillo",
                                        Email = "Finle.TRUJIL3397@mail2web.com",
                                        Login = "finltrujil8466",
                                        Password = "6CEE1DFC0793B98EC94E1A406F86E23C9AB65FBC",
                                        Sex = "F",
                                        CountryId = 4,
                                        PhoneNumber = "(817) 531-925312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("4.6.1977", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Romeo",
                                        LastName = "Meyers",
                                        Email = "Rome.MEY1155@yahoo.com",
                                        Login = "romey7443",
                                        Password = "D9C75AB1201361F6D5E7F146F9D604606BA72F71",
                                        Sex = "F",
                                        CountryId = 2,
                                        PhoneNumber = "(458) 579-493312",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("14.2.1989", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Jazlynn",
                                        LastName = "Albert",
                                        Email = "Jazly.ALBER7602@hushmail.com",
                                        Login = "jazlynnalber94",
                                        Password = "F2EC2D9B18E561B00BE7054672FFC742AFA5FEA7",
                                        Sex = "M",
                                        CountryId = 3,
                                        PhoneNumber = "(785) 500-151812",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("2.1.1999", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User{
                                        FirstName = "Omar",
                                        LastName = "Carroll",
                                        Email = "Oma.CARROLL6931@mail2web.com",
                                        Login = "omarcarro5105",
                                        Password = "2C3EFA2549824661B1EC83B299275193C68D3ED7",
                                        Sex = "M",
                                        CountryId = 1,
                                        PhoneNumber = "(646) 476-835712",
                                        IsDeleted = false,
                                        UserRole = 0,
                                        ConfirmedEmail = true,
                                        BirthDate= DateTime.Parse("23.7.1999", new System.Globalization.CultureInfo("ru-ru", true))},
                                    new User
                                    {
                                        FirstName = "test",
                                        LastName = "user",
                                        Email = "test_user@gmail.com",
                                        Login = "test_user",
                                        Password = "DCF05BF73C524F3E32C08ACF55BE3EC4170FFED5",
                                        Sex = "Мужской",
                                       CountryId = 1,
                                        PhoneNumber = "(29) 227 02 83 376",
                                        IsDeleted = false,
                                        UserRole = UserRoles.Customer,
                                        ConfirmedEmail = true
                                    },
                                new User
                                    {
                                        FirstName = "test",
                                        LastName = "admin",
                                        Email = "test_admin@gmail.com",
                                        Login = "test_admin",
                                        Password = "AA7130C1A9D96562ADE20DC00E38360B1C402975",
                                        Sex = "Мужской",
                                       CountryId = 1,
                                        PhoneNumber = "(29) 227 02 83 376",
                                        IsDeleted = false,
                                        UserRole = UserRoles.Admin,
                                        ConfirmedEmail = true
                                    },
                                new User
                                    {
                                        UserRole = UserRoles.Admin,
                                        Login = "admin",
                                        FirstName = "admin",
                                        LastName = "admin",
                                        Email = "admin@shop.com",
                                        Sex = "Мужской",
                                        ConfirmedEmail = true,
                                        Password = "8D66A53A381493BEC08DA23CEF5A43767F20A42C" // admin123!
                                    },
                                new User
                                    {
                                        UserRole = UserRoles.Seller,
                                        Login = "seller",
                                        FirstName = "seller",
                                        LastName = "seller",
                                        Email = "seller@shop.com",
                                        Sex = "Мужской",
                                        ConfirmedEmail = true,
                                        Password = "1C1947F409978BC0A2601027FCCA6290583A60D9" // seller123!
                                    },
                                new User
                                    {
                                        UserRole = UserRoles.Buyer,
                                        Login = "buyer",
                                        FirstName = "buyer",
                                        LastName = "buyer",
                                        Email = "buyer@shop.com",
                                        Sex = "Мужской",
                                        ConfirmedEmail = true,
                                        Password = "06490A9E09845EC0AAC622A6C43DAB47A516B096" // buyer123!
                                    },
                                new User
                                    {
                                        UserRole = UserRoles.Customer,
                                        Login = "user",
                                        FirstName = "user",
                                        LastName = "user",
                                        Email = "user@shop.com",
                                        Sex = "Мужской",
                                        ConfirmedEmail = true,
                                        Password = "C0018FDBFC43F406264C2A3D82CAB7373AE090A1" // user123!
                                    }
                            });

                context.SaveChanges();

                var users = context.Set<User>().ToList();

                foreach (var user in users)
                {
                    context.Set<UserData>()
                        .AddOrUpdate(new UserData { CurrencyId = 1, PriceLevelId = 1, UserId = user.Id });
                }

                context.SaveChanges();
            }
        }

        private void AddDefaultPurchasedItems(ShopContext context)
        {
            if (!context.Set<PaymentTransaction>().Any())
            {
                var userData = context.Set<UserData>().FirstOrDefault(u => u.User.Login.Equals("buyer", StringComparison.OrdinalIgnoreCase));
                var tracks = context.Set<Track>().OrderBy(t => t.Id).Skip(5).Take(5).ToList();
                var albums = context.Set<Album>().Where(a => a.Tracks.Any()).OrderBy(t => t.Id).Take(5).ToList();
                var paymentTransaction = new PaymentTransaction()
                {
                    CurrencyId = userData.UserCurrency.Id,
                    UserId = userData.UserId,
                    Date = DateTime.Now,
                    Totals = 11,
                    PurchasedTrack = tracks.Select(t => new PurchasedTrack
                    {
                        TrackId = t.Id,
                        UserId = userData.UserId,
                        //CurrencyId = t.TrackPrices.FirstOrDefault() != null ? t.TrackPrices.FirstOrDefault().CurrencyId : 1,
                        //Price = t.TrackPrices.FirstOrDefault() != null ? t.TrackPrices.FirstOrDefault().Price : 1
                        CurrencyId = 1,
                        Price = (decimal)1.99
                    })
                                           .ToList(),
                    PurchasedAlbum = albums.Select(a => new PurchasedAlbum
                    {
                        AlbumId = a.Id,
                        UserId = userData.Id,
                        CurrencyId = 1,
                        Price = 13.97m
                    })
                                           .ToList()
                };
                context.Set<PaymentTransaction>().AddOrUpdate(paymentTransaction);
                context.SaveChanges();
            }
        }

        private void AddDefaultCountries(ShopContext context)
        {
            if (!context.Set<Country>().Any())
            {
                context.Set<Country>().AddOrUpdate(
                    new Country[]
                    {
                        new Country { Name = "Беларусь" },
                        new Country { Name = "Австралия" },
                        new Country { Name = "США"},
                        new Country { Name = "Великобритания" }
                    }
                    );
            }
        }
    }
}