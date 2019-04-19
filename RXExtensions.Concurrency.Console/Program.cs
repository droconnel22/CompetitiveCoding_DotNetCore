namespace RXExtensions.Concurrency.Console
{
    using System;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Threading.Tasks;
    using System.Windows.Input;

    class Program
    {
        private static Subject<AppCommand> InnerCommands;

        public static IObservable<AppCommand> Commands
        {
            get { return InnerCommands; }
        }

        static void Main(string[] args)
        {
            // Schedule
            // ToObservable, SubscribeOn, ObserveOn
            Console.WriteLine();
            var numbers = Enumerable.Range(0, 1000);
            var obsevableNumbers = numbers.ToObservable(Scheduler.Default);
            var numbersAsTask = new Task(NumbersDelegate);

            // await Observable.StartAsync(() => numbersAsTask);
            Observable.Return(42);


            // in this cas we take a hot observerable and cool it down to a cold observable
            // we do this with the subscribe
            var simpleObvs = Observable
                    .Range(1, 10);

            simpleObvs
                .Subscribe(
                (int v) => { Console.WriteLine(v); },
                (Exception exception) => { Console.WriteLine("YA blew it"); },
                () => { Console.WriteLine("All Done!"); });

            simpleObvs
                .Subscribe(
                    (int v) => { Console.WriteLine("Take 2: " + v); },
                    (Exception exception) => { Console.WriteLine("YA blew it"); },
                    () => { Console.WriteLine("All Done 2!"); });


            Observable
                .Interval(new TimeSpan(0, 0, 0, 0, 200));

            Observable
                .Timer(new TimeSpan(0, 0, 0, 0, 200));

            Observable
                .Create<int>(observer =>
                {
                    observer.OnNext(42);
                    observer.OnCompleted();
                    return Disposable.Empty;
                });

            Observable.Generate(1,
                value => value < 5,
                value => value++,
                value => value);

            // In reality much easier to use Subject.
            // A subject is simulatenously an observable and an observer

            var subject = new Subject<string>();

            subject.Subscribe(t => Console.WriteLine(t));

            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnNext("c");



            // Warming
            var coldObservable = Observable.Range(1, 5);
            var warmObservable = coldObservable.Publish();

            warmObservable
                .Subscribe(
                    (int v) => { Console.WriteLine(v); },
                    (Exception exception) => { Console.WriteLine("YA blew it"); },
                    () => { Console.WriteLine("All Done!"); });

            warmObservable
                .Subscribe(
                    (int v) => { Console.WriteLine("Take 2: " + v); },
                    (Exception exception) => { Console.WriteLine("YA blew it"); },
                    () => { Console.WriteLine("All Done 2!"); });

            // Remember subjects are both observers and observables.
            InnerCommands = new Subject<AppCommand>();
            BindCommandHandlers();


            Console.ReadLine();

        }

        private static void BindCommandHandlers()
        {
            Commands
                .OfType<ICommand>()
                .Subscribe(t =>
                {
                    Console.WriteLine("Navigate to window");
                });
        }

        private static void NumbersDelegate()
        {
            Console.WriteLine("Derpy derp");
        }
    }

    public abstract class AppCommand
    {
        public DateTime Issued { get; private set; }
        public string Issuer { get; private set; }

        public AppCommand()
        {
            this.Issued = DateTime.Now;
            this.Issuer = "ekscptic";
        }
    }

    public class Ticket
    {

    }

    public class TicketDetailsCommand : AppCommand
    {
        public Ticket Ticket { get; private set; }

        public TicketDetailsCommand(Ticket ticket) : base()
        {
            Ticket = ticket;
        }
    }
}
