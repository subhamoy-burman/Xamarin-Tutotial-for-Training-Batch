using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BookSwap.Local.Model;
using MvvmHelpers;
using Xamarin.Forms;

namespace BookSwap.Local.ViewModels
{
    public class BooksViewModel : ObservableObject
    {
        private Book _selectedBook;

        public IList<Book> Books { get; set; }
        public Book SwapFromBook { get; set; }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set { SetProperty<Book>(ref _selectedBook, value); }
        }


        public BooksViewModel()
        {

            SwapFromBook = new Book()
            {
                Title = "Extremely Loud and Incredibly Close",
                Author = "Jonathan Safran Foer",
                Colors = new ColorValues
                {
                    Accent = Color.FromHex("#FFF571"),
                    DarkAccent = Color.FromHex("#F1EE55"),
                    ExtraDarkAccent = Color.FromHex("#F3DD3F"),
                    TitleColor = Color.FromHex("#F00D39"),
                    AccentTextColor = Color.FromHex("#B7A701"),
                },
                UserImage = "https://randomuser.me/api/portraits/women/12.jpg",
                Description = "Oskar Schell is a super-smart nine-year old grieving the loss of his father, Thomas, who was killed in the World Trade Center attacks on September 11, 2001. He's feeling depressed and anxious, and feels angry and distant towards his mother.",
                CoverImage = "book_extremelyloud",
            };

            Books = new ObservableRangeCollection<Book>() {

                new Book() {

                    Title = "Everything is Illuminated",
                    Author = "Jonthon",
                    AccentColor = "#0FF4C3",
                    Colors = ColorPalette.GetNextColorValues(),
                    CoverImage =  "book_illuminated"
                },
                new Book() {

                    Title = "Everything is Illuminated",
                    Author = "Jonthon",
                    AccentColor = "#B76EFE",
                    Colors = ColorPalette.GetNextColorValues(),
                    CoverImage =  "book_hobbit"
                },
                new Book() {

                    Title = "Everything is Illuminated",
                    Author = "Jonthon",
                    AccentColor = "#0FF4C3",
                    Colors = ColorPalette.GetNextColorValues(),
                    CoverImage =  "book_ulysses"
                },
                new Book() {

                    Title = "Everything is Illuminated",
                    Author = "Jonthon",
                    AccentColor = "#B76EFE",
                    Colors = ColorPalette.GetNextColorValues(),
                    CoverImage =  "book_illuminated"
                },
                new Book() {

                    Title = "Everything is Illuminated",
                    Author = "Jonthon",
                    AccentColor = "#0FF4C3",
                    Colors = ColorPalette.GetNextColorValues(),
                    CoverImage =  "book_illuminated"
                },
                new Book() {

                    Title = "Everything is Illuminated",
                    Author = "Jonthon",
                    AccentColor = "#B76EFE",
                    Colors = ColorPalette.GetNextColorValues(),
                    CoverImage =  "book_hobbit"
                },
                new Book() {

                    Title = "Everything is Illuminated",
                    Author = "Jonthon",
                    AccentColor = "#0FF4C3",
                    Colors = ColorPalette.GetNextColorValues(),
                    CoverImage =  "book_ulysses"
                },
                new Book() {

                    Title = "Everything is Illuminated",
                    Author = "Jonthon",
                    AccentColor = "#B76EFE",
                    Colors = ColorPalette.GetNextColorValues(),
                    CoverImage =  "book_illuminated"
                }
            };
        }
    }
}
