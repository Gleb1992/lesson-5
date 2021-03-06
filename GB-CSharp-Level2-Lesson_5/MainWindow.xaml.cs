﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace GB_CSharp_Level2_Lesson_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Урок 5. Знакомство с технологией WPF. 
        //Создать WPF-приложение для ведения списка сотрудников компании.
        //1. Создать сущности Employee и Department и заполните списки сущностей начальными данными.
        //2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). Это можно сделать, например, с использованием ComboBox или ListView.
        //3. Предусмотреть возможность редактирования сотрудников и департаментов. Должна быть возможность изменить департамент у сотрудника.Список департаментов для выбора, можно выводить в ComboBox, это все можно выводить на дополнительной форме.
        //4. Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.
        
        Company company = new Company();
        ObservableCollection<Employee> employees1;
        ObservableCollection<Employee> employees2;
        string dep1_name;
        string dep2_name;
        public MainWindow()
        {
            InitializeComponent();

            var allName = new string[] { "Аарон", "Абрам", "Август", "Августин", "Авксентий", "Авраам", "Агап", "Агафон", "Адис", "Адольф", "Азарий", "Азат", "Айрат", "Акакий", "Алан", "Алевтин", "Алексий", "Ален", "Алмаз", "Алоис", "Альфред", "Амадей", "Амвросий", "Амин", "Анвар", "Ангел", "Андрон", "Андрэ", "Анисим", "Антип", "Ануфрий", "Анфим", "Арам", "Арий", "Арман", "Армен", "Арон", "Арсен", "Артамон", "Артем", "Архип", "Архипп", "Афанасий", "Афиноген", "Бахрам", "Бежен", "Бернар", "Богдан", "Бонифаций", "Бореслав", "Боян", "Бронислав", "Вадим", "Валентин", "Вальдемар", "Вальтер", "Варлам", "Варфоломей", "Вацлав", "Велизар", "Венедикт", "Вениамин", "Вилен", "Вилли", "Виталий", "Витаутас", "Владимир", "Владислав", "Власий", "Володар", "Вячеслав", "Гавриил", "Гайдар", "Галактион", "Гаспар", "Гастон", "Геворг", "Геласий", "Генри", "Генрих", "Герасим", "Герман", "Гоар", "Гордей", "Градимир", "Граф", "Густав", "Давид", "Дамиан", "Дамир", "Данила", "Данислав", "Дементий", "Демид", "Денис", "Джамал", "Джозеф", "Джордан", "Дик", "Димитрий", "Диомид", "Дмитрий", "Донат", "Донатос", "Евграф", "Евдоким", "Евсей", "Евстафий", "Елизар", "Елисей", "Еремей", "Ермак", "Ерофей", "Ефим", "Жан", "Ждан", "Закир", "Замир", "Захария", "Зенон", "Зорий", "Зосима", "Иакинф", "Ибрагим", "Игнатий", "Игорь", "Израиль", "Изяслав", "Илларион", "Ильхам", "Ильяс", "Иннокентий", "Иоанн", "Ион", "Иосиф", "Ипполит", "Ириней", "Ириний", "Исаакий", "Исай", "Искандер", "Ислам", "Июлий", "Казбек", "Камиль", "Капитон", "Карл", "Каспар", "Кир", "Кирилл", "Клемент", "Клементий", "Клод", "Кондрат", "Конрад", "Константин", "Краснослав", "Ксаннф", "Лавр", "Лаврентий", "Лев", "Леван", "Леон", "Леонард", "Леопольд", "Лермонт", "Лукий", "Лукьян", "Людвиг", "Люсьен", "Магистриан", "Мадлен", "Макар", "Макарий", "Максимилиан", "Максимильян", "Мануил", "Мар", "Марин", "Марк", "Марсель", "Мартин", "Махмуд", "Мелентий", "Мечеслав", "Мечислав", "Милан", "Милен", "Мирон", "Мирослав", "Митя", "Михаил", "Модест", "Моисей", "Муслим", "Мухаммед", "Назарий", "Наиль", "Неонил", "Нестор", "Никифор", "Никодим", "Никон", "Нил", "Нифонт", "Новомир", "Овидий", "Октябрь", "Олесь", "Ольгерд", "Орест", "Орландо", "Остап", "Остромир", "Панкрат", "Пантелеймон", "Парфений", "Пахом", "Пимен", "Платон", "Прозор", "Прокопий", "Прохор", "Равиль", "Радислав", "Радомир", "Разумник", "Раис", "Рамазан", "Рамиз", "Ранель", "Расим", "Ратмир", "Рафаил", "Рашид", "Рем", "Рифат", "Рихард", "Родион", "Ролан", "Рубен", "Рудольф", "Руфин", "Рушан", "Савва", "Савел", "Самсон", "Самуил", "Светозар", "Светослав", "Святослав", "Севастьян", "Северьян", "Семен", "Сидор", "Сильвестр", "Сократ", "Соломон", "Стакрат", "Сталий", "Степан", "Стефан", "Султан", "Тагир", "Талик", "Тамаз", "Тельман", "Тельнан", "Тибор", "Тиграм", "Тимон", "Тимофей", "Тихомир", "Тихон", "Трофим", "Тунгуз", "Устин", "Фаддей", "Фанис", "Фарид", "Федосей", "Федот", "Феодосий", "Фердинанд", "Филимон", "Филипп", "Франц", "Фред", "Фуад", "Хабиб", "Христиан", "Христос", "Чарльз", "Чеслав", "Шамиль", "Шарль", "Щеголь", "Эдвард", "Эдуард", "Эльдар", "Эммануил", "Эраст", "Юлиан", "Юлий", "Юстин", "Юхим", "Якун", "Ян", "Ярослав", "Ясон", };
            var allSurname = new string[] { "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов", "Егоров", "Павлов", "Козлов", "Степанов", "Николаев", "Орлов", "Андреев", "Макаров", "Никитин", "Захаров", "Зайцев", "Соловьев", "Борисов", "Яковлев", "Григорьев", "Романов", "Воробьев", "Сергеев", "Кузьмин", "Фролов", "Александров", "Дмитриев", "Королев", "Гусев", "Киселев", "Ильин", "Максимов", "Поляков", "Сорокин", "Виноградов", "Ковалев", "Белов", "Медведев", "Антонов", "Тарасов", "Жуков", "Баранов", "Филиппов", "Комаров", "Давыдов", "Беляев", "Герасимов", "Богданов", "Осипов", "Сидоров", "Матвеев", "Титов", "Марков", "Миронов", "Крылов", "Куликов", "Карпов", "Власов", "Мельников", "Денисов", "Гаврилов", "Тихонов", "Казаков", "Афанасьев", "Данилов", "Савельев", "Тимофеев", "Фомин", "Чернов", "Абрамов", "Мартынов", "Ефимов", "Федотов", "Щербаков", "Назаров", "Калинин", "Исаев", "Чернышев", "Быков", "Маслов", "Родионов", "Коновалов", "Лазарев", "Воронин", "Климов", "Филатов", "Пономарев", "Голубев", "Кудрявцев", "Прохоров", "Наумов", "Потапов", "Журавлев", "Овчинников", "Трофимов", "Леонов", "Соболев", "Ермаков", "Колесников", "Гончаров", "Емельянов", "Никифоров", "Грачев", "Котов", "Гришин", "Ефремов", "Архипов", "Громов", "Кириллов", "Малышев", "Панов", "Моисеев", "Румянцев", "Акимов", "Кондратьев", "Бирюков", "Горбунов", "Анисимов", "Еремин", "Тихомиров", "Галкин", "Лукьянов", "Михеев", "Скворцов", "Юдин", "Белоусов", "Нестеров", "Симонов", "Прокофьев", "Харитонов", "Князев", "Цветков", "Левин", "Митрофанов", "Воронов", "Аксенов", "Софронов", "Мальцев", "Логинов", "Горшков", "Савин", "Краснов", "Майоров", "Демидов", "Елисеев", "Рыбаков", "Сафонов", "Плотников", "Демин", "Хохлов", "Фадеев", "Молчанов", "Игнатов", "Литвинов", "Ершов", "Ушаков", "Дементьев", "Рябов", "Мухин", "Калашников", "Леонтьев", "Лобанов", "Кузин", "Корнеев", "Евдокимов", "Бородин", "Платонов", "Некрасов", "Балашов", "Бобров", "Жданов", "Блинов", "Игнатьев", "Коротков", "Муравьев", "Крюков", "Беляков", "Богомолов", "Дроздов", "Лавров", "Зуев", "Петухов", "Ларин", "Никулин", "Серов", "Терентьев", "Зотов", "Устинов", "Фокин", "Самойлов", "Константинов", "Сахаров", "Шишкин", "Самсонов", "Черкасов", "Чистяков", "Носов", "Спиридонов", "Карасев", "Авдеев", "Воронцов", "Зверев", "Владимиров", "Селезнев", "Нечаев", "Кудряшов", "Седов", "Фирсов", "Андрианов", "Панин", "Головин", "Терехов", "Ульянов", "Шестаков", "Агеев", "Никонов", "Селиванов", "Баженов", "Гордеев", "Кожевников", "Пахомов", "Зимин", "Костин", "Широков", "Филимонов", "Ларионов", "Овсянников", "Сазонов", "Суворов", "Нефедов", "Корнилов", "Любимов", "Львов", "Горбачев", "Копылов", "Лукин", "Токарев", "Кулешов", "Шилов", "Большаков", "Панкратов", "Родин", "Шаповалов", "Покровский", "Бочаров", "Никольский", "Маркин", "Горелов", "Агафонов", "Березин", "Ермолаев", "Зубков", "Куприянов", "Трифонов", "Масленников", "Круглов", "Третьяков", "Колосов", "Рожков", "Артамонов", "Шмелев", "Лаптев", "Лапшин", "Федосеев", "Зиновьев", "Зорин", "Уткин", "Столяров", "Зубов", "Ткачев", "Дорофеев", "Антипов", "Завьялов", "Свиридов", "Золотарев", "Кулаков", "Мещеряков", "Макеев", "Дьяконов", "Гуляев", "Петровский", "Бондарев", "Поздняков", "Панфилов", "Кочетков", "Суханов", "Рыжов", "Старостин", "Калмыков", "Колесов", "Золотов", "Кравцов", "Субботин", "Шубин", "Щукин", "Лосев", "Винокуров", "Лапин", "Парфенов", "Исаков", "Голованов", "Коровин", "Розанов", "Артемов", "Козырев", "Русаков", "Алешин", "Крючков", "Булгаков", "Кошелев", "Сычев", "Синицын", "Черных", "Рогов", "Кононов", "Лаврентьев", "Евсеев", "Пименов", "Пантелеев", "Горячев", "Аникин", "Лопатин", "Рудаков", "Одинцов", "Серебряков", "Панков", "Дегтярев", "Орехов", "Царев", "Шувалов", "Кондрашов", "Горюнов", "Дубровин", "Голиков", "Курочкин", "Латышев", "Севастьянов", "Вавилов", "Ерофеев", "Сальников", "Клюев", "Носков", "Озеров", "Кольцов", "Комиссаров", "Меркулов", "Киреев", "Хомяков", "Булатов", "Ананьев", "Буров", "Шапошников", "Дружинин", "Островский", "Шевелев", "Долгов", "Суслов", "Шевцов", "Пастухов", "Рубцов", "Бычков", "Глебов", "Ильинский", "Успенский", "Дьяков", "Кочетов", "Вишневский", "Высоцкий", "Глухов", "Дубов", "Бессонов", "Ситников", "Астафьев", "Мешков", "Шаров", "Яшин", "Козловский", "Туманов", "Басов", "Корчагин", "Болдырев", "Олейников", "Чумаков", "Фомичев", "Губанов", "Дубинин", "Шульгин", "Касаткин", "Пирогов", "Семин", "Трошин", "Горохов", "Стариков", "Щеглов", "Фетисов", "Колпаков", "Чесноков", "Зыков", "Верещагин", "Минаев", "Руднев", "Троицкий", "Окулов", "Ширяев", "Малинин", "Черепанов", "Измайлов", "Алехин", "Зеленин", "Касьянов", "Пугачев", "Павловский", "Чижов", "Кондратов", "Воронков", "Капустин", "Сотников", "Демьянов", "Косарев", "Беликов", "Сухарев", "Белкин", "Беспалов", "Кулагин", "Савицкий", "", "Жаров", "Хромов", "Еремеев", "Карташов", "Астахов", "Русанов", "Сухов", "Вешняков", "Волошин", "Козин", "Худяков", "Жилин", "Малахов", "Сизов", "Ежов", "Толкачев", "Анохин", "Вдовин", "Бабушкин", "Усов", "Лыков", "Горлов", "Коршунов", "Маркелов", "Постников", "Черный", "Дорохов", "Свешников", "Гущин", "Калугин", "Блохин", "Сурков", "Кочергин", "Греков", "Казанцев", "Швецов", "Ермилов", "Парамонов", "Агапов", "Минин", "Корнев", "Черняев", "Гуров", "Ермолов", "Сомов", "Добрынин", "Барсуков", "Глушков", "Чеботарев", "Москвин", "Уваров", "Безруков", "Муратов", "Раков", "Снегирев", "Гладков", "Злобин", "Моргунов", "Поликарпов", "Рябинин", "Судаков", "Кукушкин", "Калачев", "Грибов", "Елизаров", "Звягинцев", "Корольков", "Федосов",};
            var r = new Random();
            var dep = r.Next(2, 10);
            for(int i = 0; i < dep; ++i)
            {
                company.Departments.Add(new Department($"Отдел {i}", r.Next(-100000, 10000000)));
                var empl = r.Next(5, 40);
                for(var j = 0; j < empl; ++j)
                {
                    var rate = r.Next(10000, 100000);
                    company.Departments[i].Employees.Add(new Employee(allName[r.Next(0, allName.Length)], r.Next(18, 100), rate, rate));
                }
            }

            listDepartment.ItemsSource = company.Departments;
            listDepartment.SelectionChanged += delegate { SelectDepartment(); };
            listEmployee.SelectionChanged += delegate { SelectEmployee(); };
            btn_dep.Click += delegate { OpenWindowDepartment(); };
            btn_dep_clone.Click += delegate { CloneDepartment(); };
            btn_employee_clone.Click += delegate { CloneEmployee(); };
            btn_employee_del.Click += delegate { DelEmployee(); };
            btn_dep_del.Click += delegate { DelDepartment(); };
        }


        /// <summary>
        /// Событие при выборе отдела
        /// </summary>
        public void SelectDepartment()
        {
            var e = company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault(); 
            if(e != null)
                listEmployee.ItemsSource = employees1 = company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault().Employees;
        }
        /// <summary>
        /// Событие при выборе сотрудника
        /// </summary>
        public void SelectEmployee()
        {
            var e = company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault().Employees?.Where(x => x == listEmployee.SelectedItem).FirstOrDefault();
            if(e != null)
                (new WindowEmployee(
                    company.Departments.Where(x => x == listDepartment.SelectedItem).FirstOrDefault().Employees.Where(x => x == listEmployee.SelectedItem).FirstOrDefault(),
                    company.Departments.Where(x => x == listDepartment.SelectedItem).FirstOrDefault(), company, listEmployee)).Show();
        }

        /// <summary>
        /// Удаление отдела
        /// </summary>
        public void DelDepartment()
        {
            var dep = company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault();
            if (dep != null && company?.Departments?.Count > 1)
                company?.Departments?.Remove(dep);
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        public void DelEmployee()
        {
            var empl = company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault().Employees.Where(x => x == listEmployee.SelectedItem).FirstOrDefault();
            if (empl != null && company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault().Employees.Count > 1)
                company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault().Employees.Remove(empl);
        }

        /// <summary>
        /// Копирование отдела
        /// </summary>
        public void CloneDepartment()
        {
            var dep = company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault();
            if (dep != null)
                company?.Departments?.Add(dep);
        }

        /// <summary>
        /// Копирование сотрудника
        /// </summary>
        public void CloneEmployee()
        {
            var empl = company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault().Employees.Where(x => x == listEmployee.SelectedItem).FirstOrDefault();
            if (empl != null)
                company?.Departments?.Where(x => x == listDepartment.SelectedItem).FirstOrDefault().Employees.Add(empl);
        }
        
        /// <summary>
        /// Открытие окна редактирования отдела
        /// </summary>
        public void OpenWindowDepartment() => (new WindowDepartment(company.Departments.Where(x => x == listDepartment.SelectedItem).FirstOrDefault(), company, listDepartment)).Show();

        private void ListDepartment_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListEmployee_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
