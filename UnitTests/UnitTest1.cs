using System;
using System.Linq;
using Entities;
using Infrastructure;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddYes()
        {
            var yes = new Band() { Name = "Yes" };

            using (var context = new MusicContext())
            {
                var existing = context.Bands.SingleOrDefault(b => b.Name.Equals(yes.Name));

                if (existing == null)
                {
                    context.Bands.Add(yes);
                    context.SaveChanges();
                }
            }
        }

        [Theory]
        [InlineData("Steve", "Howe", "1970–1981", "Guitar")]
        [InlineData("Steve", "Howe", "1990–1992", "Guitar")]
        [InlineData("Steve", "Howe", "1995–Present", "Guitar")]
        [InlineData("Alan", "White", "1972-1981", "Drums")]
        [InlineData("Alan", "White", "1982-2004", "Drums")]
        [InlineData("Alan", "White", "2008-present", "Drums")]
        [InlineData("Geoff", "Downes", "1980-1981", "Keyboards")]
        [InlineData("Geoff", "Downes", "2011-present", "Keyboards")]
        [InlineData("Billy", "Sherwood", "1997–2000", "Bass")]
        [InlineData("Billy", "Sherwood", "2015-present", "Bass")]
        [InlineData("Jon", "Davison", "2012-present", "Vocals")]
        [InlineData("Jon", "Anderson", "1968-1980", "Vocals")]
        [InlineData("Jon", "Anderson", "1982-1988", "Vocals")]
        [InlineData("Jon", "Anderson", "1990-2004", "Vocals")]
        [InlineData("Chris", "Squire", "1968–1981", "Bass")]
        [InlineData("Chris", "Squire", "1982–2004", "Bass")]
        [InlineData("Chris", "Squire", "2008–2015", "Bass")]
        [InlineData("Tony", "Kaye", "1968–1971", "Keyboards")]
        [InlineData("Tony", "Kaye", "1982–1983", "Keyboards")]
        [InlineData("Tony", "Kaye", "1983–1994", "Keyboards")]
        [InlineData("Bill", "Bruford", "1968-1972", "Drums")]
        [InlineData("Bill", "Bruford", "1990–1992", "Drums")]
        [InlineData("Peter", "Banks", "1968–1970", "Guitar")]
        [InlineData("Tony", "O'Reilly", "1968–1968", "Drums")]
        [InlineData("Rick", "Wakeman", "1971–1974", "Keyboards")]
        [InlineData("Rick", "Wakeman", "1976–1980", "Keyboards")]
        [InlineData("Rick", "Wakeman", "1990–1992", "Keyboards")]
        [InlineData("Rick", "Wakeman", "1995–1996", "Keyboards")]
        [InlineData("Rick", "Wakeman", "2002–2004", "Keyboards")]
        [InlineData("Patrick", "Moraz", "1974–1976", "Keyboards")]
        [InlineData("Trevor", "Horn", "1980–1981", "Vocals")]
        [InlineData("Trevor", "Rabin", "1982–1994", "Guitar")]
        [InlineData("Eddie", "Jobson", "1983-1983", "Keyboards")]
        [InlineData("Igor", "Khoroshev", "1997–2000", "Keyboards")]
        [InlineData("Benoît", "David", "2008–2012", "Vocals")]
        [InlineData("Oliver", "Wakeman", "2008–2011", "Keyboards")]
        public void AddMembers(string first, string last, string term, string instrument)
        {

            var member = new BandMember() { Term = term };

            using (var context = new MusicContext())
            {
                member.Member = context.People.SingleOrDefault(b => b.FirstName.Equals(first)
                    && b.LastName.Equals(last));
                member.Instrument = context.Instruments.SingleOrDefault(b => b.Description.Equals(instrument));
                member.Band = context.Bands.SingleOrDefault(b => b.Name.Equals("Yes"));

                var existing = context.Bands.SingleOrDefault(b => b.Name.Equals("Yes")
                        && b.Members.Count(m => m.Member.FirstName.Equals(first)
                        && m.Member.LastName.Equals(last)
                        && m.Instrument.Description.Equals(instrument)
                    ) > 0
                );

                if (existing == null)
                {
                    context.BandMembers.Add(member);
                    context.SaveChanges();
                }
            }
        }

        [Theory]
        [InlineData("Guitar")]
        [InlineData("Drums")]
        [InlineData("Keyboards")]
        [InlineData("Bass")]
        [InlineData("Vocals")]
        public void AddInstruments(string desc)
        {
            var instrument = new Instrument() { Description = desc };

            using (var context = new MusicContext())
            {
                var existing = context.Instruments.SingleOrDefault(b => b.Description.Equals(instrument.Description));

                if (existing == null)
                {
                    context.Instruments.Add(instrument);
                    context.SaveChanges();
                }
            }
        }

        [Theory]
        [InlineData("Steve", "Howe")]
        [InlineData("Alan", "White")]
        [InlineData("Geoff", "Downes")]
        [InlineData("Billy", "Sherwood")]
        [InlineData("Jon", "Davison")]
        [InlineData("Jon", "Anderson")]
        [InlineData("Chris", "Squire")]
        [InlineData("Tony", "Kaye")]
        [InlineData("Bill", "Bruford")]
        [InlineData("Peter", "Banks")]
        [InlineData("Tony", "O'Reilly")]
        [InlineData("Rick", "Wakeman")]
        [InlineData("Patrick", "Moraz")]
        [InlineData("Trevor", "Horn")]
        [InlineData("Trevor", "Rabin")]
        [InlineData("Eddie", "Jobson")]
        [InlineData("Igor", "Khoroshev")]
        [InlineData("Benoît", "David")]
        [InlineData("Oliver", "Wakeman")]
        public void AddPeople(string first, string last)
        {
            var person = new Person() { FirstName = first, LastName = last };

            using (var context = new MusicContext())
            {
                var existing = context.People.SingleOrDefault(b => b.FirstName.Equals(person.FirstName) 
                    && b.LastName.Equals(person.LastName));

                if (existing == null)
                {
                    context.People.Add(person);
                    context.SaveChanges();
                }
            }
        }

    }
}
