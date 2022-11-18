namespace Peano.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private RuleQuantifiedVariablesSubstitute ruleQuantifiedVariablesSubstitute;
        private RuleEqualsSubstitute ruleEqualsSubstitute;
        private RuleModusPonens ruleModusPonens;
        private QuantifiedTerm axiom_equals_commutes;
        private QuantifiedTerm axiom_peano6;
        private QuantifiedTerm exercise1;
        private Variable x;
        private Variable y;
        private Variable z;
        private FunctionType equals;
        private FunctionType add;
        private Variable w;
        private Variable _0;
        private FunctionType implies;

        [TestInitialize]
        public void TestInitialize()
        {
            _0 = new Variable() { Name = "0" };
            equals = new FunctionType("equals");
            implies = new FunctionType("implies");
            add = new FunctionType("add");
            w = new Variable() { Name = "w" };
            x = new Variable() { Name = "x" };
            y = new Variable() { Name = "y" };
            z = new Variable() { Name = "z" };

            ruleQuantifiedVariablesSubstitute = new RuleQuantifiedVariablesSubstitute();
            ruleEqualsSubstitute = new RuleEqualsSubstitute();
            ruleModusPonens = new RuleModusPonens();

            axiom_equals_commutes = new QuantifiedTerm(
                implies.Term(
                    equals.Term(x, y),
                    equals.Term(y, x)
                    ),
                new Quantifier(QuantifierType.All, x),
                new Quantifier(QuantifierType.All, y)
                );

            axiom_peano6 = new QuantifiedTerm(
                equals.Term(
                    add.Term(x, _0),
                    x
                ),
                new Quantifier(QuantifierType.All, x)
                );

            exercise1 = new QuantifiedTerm(
                equals.Term(
                    add.Term(x, add.Term(y, _0)),
                    add.Term(x, add.Term(y, _0))
                ),
                new Quantifier(QuantifierType.All, x),
                new Quantifier(QuantifierType.All, y)
                );

        }

        [TestMethod]
        public void axiom_equals_commutes_toString()
        {
            var a = axiom_equals_commutes.ToString();

            Assert.AreEqual(a, "all x all y implies(equals(x,y),equals(y,x))");
        }

        [TestMethod]
        public void e1_step4()
        {
            var b = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_peano6,
                new Dictionary<Variable, Term>
                {
                    [x] = y
                },
                new Quantifier(QuantifierType.All, y));

            var c = ruleEqualsSubstitute.Apply(exercise1, b, 1);

            Assert.AreEqual(c.ToString(), "all x all y equals(add(x,add(y,0)),add(x,y))");

            var d = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_peano6,
                new Dictionary<Variable, Term>
                {
                    [x] = z
                },
                new Quantifier(QuantifierType.All, z));
            Assert.AreEqual(d.ToString(), "all z equals(add(z,0),z)");

            var e = ruleQuantifiedVariablesSubstitute.Apply(
                d,
                new Dictionary<Variable, Term>
                {
                    [z] = add.Term(x, y)
                },
                new Quantifier(QuantifierType.All, x),
                new Quantifier(QuantifierType.All, y));

            Assert.AreEqual(e.ToString(), "all x all y equals(add(add(x,y),0),add(x,y))");

            var f = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_equals_commutes,
                new Dictionary<Variable, Term>
                {
                    [x] = w,
                    [y] = z
                },
                new Quantifier(QuantifierType.All, w),
                new Quantifier(QuantifierType.All, z));
            Assert.AreEqual(f.ToString(), "all w all z implies(equals(w,z),equals(z,w))");

            var g = ruleQuantifiedVariablesSubstitute.Apply(
                f,
                new Dictionary<Variable, Term>
                {
                    [w] = add.Term(add.Term(x,y),_0),
                    [z] = add.Term(x, y)
                },
                new Quantifier(QuantifierType.All, x),
                new Quantifier(QuantifierType.All, y));
            Assert.AreEqual(g.ToString(), "all x all y implies(equals(add(add(x,y),0),add(x,y)),equals(add(x,y),add(add(x,y),0)))");

            var h = ruleModusPonens.Apply(g, e);
            Assert.AreEqual(h.ToString(), "all x all y equals(add(x,y),add(add(x,y),0))");

            //var f 
            //Assert.AreEqual(f.ToString(), "all x all y equals(add(x,y),add(add(x,y),0))");
        }

        [TestMethod]
        public void e1_step3()
        {
            var b = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_peano6,
                new Dictionary<Variable, Term>
                {
                    [x] = y
                },
                new Quantifier(QuantifierType.All, y));

            var c = ruleEqualsSubstitute.Apply(exercise1, b, 1);

            Assert.AreEqual(c.ToString(), "all x all y equals(add(x,add(y,0)),add(x,y))");

            var d = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_peano6,
                new Dictionary<Variable, Term>
                {
                    [x] = z
                },
                new Quantifier(QuantifierType.All, z));
            Assert.AreEqual(d.ToString(), "all z equals(add(z,0),z)");

            var e = ruleQuantifiedVariablesSubstitute.Apply(
                d,
                new Dictionary<Variable, Term>
                {
                    [z] = add.Term(x, y)
                },
                new Quantifier(QuantifierType.All, x),
                new Quantifier(QuantifierType.All, y));

            Assert.AreEqual(e.ToString(), "all x all y equals(add(add(x,y),0),add(x,y))");
        }

        [TestMethod]
        public void e1_step2()
        {
            var b = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_peano6,
                new Dictionary<Variable, Term>
                {
                    [x] = y
                },
                new Quantifier(QuantifierType.All, y));

            var c = ruleEqualsSubstitute.Apply(exercise1, b, 1);

            Assert.AreEqual(c.ToString(), "all x all y equals(add(x,add(y,0)),add(x,y))");

            var d = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_peano6,
                new Dictionary<Variable, Term>
                {
                    [x] = z
                },
                new Quantifier(QuantifierType.All, z));
            Assert.AreEqual(d.ToString(), "all z equals(add(z,0),z)");

            var e = ruleQuantifiedVariablesSubstitute.Apply(
                d,
                new Dictionary<Variable, Term>
                {
                    [z] = add.Term(x, y)
                },
                new Quantifier(QuantifierType.All, x),
                new Quantifier(QuantifierType.All, y));

            Assert.AreEqual(e.ToString(), "all x all y equals(add(add(x,y),0),add(x,y))");
        }

        [TestMethod]
        public void e1_step1()
        {
            var b = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_peano6,
                new Dictionary<Variable, Term>
                {
                    [x] = y
                },
                new Quantifier(QuantifierType.All, y));

            var c = ruleEqualsSubstitute.Apply(exercise1, b, 1);

            Assert.AreEqual(c.ToString(), "all x all y equals(add(x,add(y,0)),add(x,y))");
        }

        [TestMethod]
        public void e1_toString()
        {
            var a = exercise1.ToString();

            Assert.AreEqual(a, "all x all y equals(add(x,add(y,0)),add(x,add(y,0)))");
        }
        [TestMethod]
        public void TestMethod1()
        {
            FunctionType is_number = new FunctionType("is_number");
            FunctionType implies = new FunctionType("implies");
            FunctionType S = new FunctionType("S");
            var axiom_peano1 = new QuantifiedTerm(
                is_number.Term(_0),
                new Quantifier(QuantifierType.Exists, _0)
                );
            var axiom_peano2 = new QuantifiedTerm(
                implies.Term(is_number.Term(x), is_number.Term(S.Term(x))),
                new Quantifier(QuantifierType.All, x)
                );

            var axiom_peano7 = new QuantifiedTerm(
                equals.Term(
                    add.Term(x, S.Term(y)),
                    S.Term(add.Term(x,y))
                ),
                new Quantifier(QuantifierType.All, x),
                new Quantifier(QuantifierType.All, y)
                );

            var term1 = new QuantifiedTerm(
                    add.Term(x, add.Term(y, _0)),
                new Quantifier(QuantifierType.All, x),
                new Quantifier(QuantifierType.All, y)
                );
        }

        [TestMethod]
        public void axiom6()
        {
            var a = axiom_peano6.ToString();

            Assert.AreEqual(a, "all x equals(add(x,0),x)");
        }

        [TestMethod]
        public void axiom6_substituted()
        {
            var a = ruleQuantifiedVariablesSubstitute.Apply(
                axiom_peano6,
                new Dictionary<Variable, Term>
                {
                    [x] = y
                },
                new Quantifier(QuantifierType.All, y)).ToString();

            Assert.AreEqual(a, "all y equals(add(y,0),y)");
        }
    }
}