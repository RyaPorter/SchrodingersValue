using System;
using NUnit.Framework;
using SchrodingersValue;

namespace SchrodingersValue.Tests
{
    public class Tests
    {

        [Test]
        public void OpenAnEmptyBox()
        {
            Box<string> emptyBox = Box<string>.Empty;

            emptyBox.Open(
                (e) =>
                {
                    Assert.Fail();
                },
                () =>
                {
                    Assert.Pass();
                }
            );
        }

        [Test]
        public void OpenBoxWithValue()
        {
            Box<string> box = Box<string>.Create("Cat Is Alive");

            box.Open(
                (e) =>
                {
                    Assert.AreEqual("Cat Is Alive", e);
                },
                () =>
                {
                    Assert.Fail();
                }
            );
        }

        [Test]
        public void openBoxWithNullReference()
        {
            Box<string> box = Box<string>.Create(null);
            Assert.AreEqual(Box<string>.Empty, box);
        }

        [Test]
        public void CallingMethodReturningEmptyBox()
        {
            MethodReturningBox("hello").Open(
                (b) =>
                {
                    Assert.Fail();
                },
                () =>
                {
                    Assert.Pass();
                }
            );
        }

        [Test]
        public void CallingMethodReturningBox()
        {
            MethodReturningBox("yes").Open(
                (b) =>
                {
                    Assert.Pass();
                },
                () =>
                {
                    Assert.Fail();
                }
            );
        }

        private Box<bool> MethodReturningBox(string boolString)
        {
            switch (boolString.ToLower())
            {
                case "yes":
                    {
                        return true;
                    }
                case "no":
                    {
                        return false;
                    }
                default:
                    {
                        return Box<bool>.Empty;
                    }
            }
        }
    }
}