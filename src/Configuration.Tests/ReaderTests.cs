using NUnit.Framework;
using System;
using Moq;

namespace Configuration.Tests
{
    // public class JobSummary {
    //     public readonly string Title;
    //     public readonly string Company;
    //     public readonly string Location;
    //     public readonly string DatePosted;
    //     public readonly string Description;
    // }

    public class Jobs {
        // public readonly string Path;

        // public readonly JobSummary JobSummary;
    }

    public class Configuration {
        public readonly string Source;
        public readonly Jobs Jobs;

        public Configuration(IReadConfiguration options) {
            this.Source = options.GetSource();
            this.Jobs  = options.GetJobs();
        }
    }

    public class ReaderTests
    {
        private Moq.Mock<IReadConfiguration> readConfiguration;

        [SetUp]
        public void Setup()
        {
            readConfiguration = new Moq.Mock<IReadConfiguration>();
        }

        [Test]
        public void ShouldGetSource()
        {
            var expectedSource = "https://my-source";
            this.readConfiguration.Setup(x => x.GetSource()).Returns(expectedSource);

            var configuration = new Configuration(this.readConfiguration.Object);
            
            this.readConfiguration.Verify(x => x.GetSource(), Times.Once());
            Assert.AreEqual(expectedSource, configuration.Source);
        }

        [Test]
        public void ShouldGetJobs() {
            var expectedJobs = new Jobs();
            this.readConfiguration.Setup(x => x.GetJobs()).Returns(expectedJobs);

            var configuration = new Configuration(this.readConfiguration.Object);

            this.readConfiguration.Verify(x => x.GetJobs(), Times.Once);
            Assert.AreEqual(expectedJobs, configuration.Jobs);
        }
    }
}
