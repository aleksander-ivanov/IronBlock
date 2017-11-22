using System.Collections.Generic;
using System.IO;
using System.Linq;
using IronBlock.Blocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronBlock.Tests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void Test_Logic_Boolean()
        {

            const string xml = @"
<xml>
    <block type=""logic_boolean"">
        <field name=""BOOL"">TRUE</field>
    </block>           
</xml>
";
            var output = new Parser()
                .AddStandardBlocks()
                .Parse(xml)
                .Evaluate();
            
            Assert.AreEqual(true, output);
        }


        [TestMethod]
        public void Test_Logic_Operation_Or()
        {
            
            const string xml = @"
<xml xmlns=""http://www.w3.org/1999/xhtml"">
  <block type=""logic_operation"">
    <field name=""OP"">OR</field>
    <value name=""A"">
      <block type=""logic_boolean"">
        <field name=""BOOL"">FALSE</field>
      </block>
    </value>
    <value name=""B"">
      <block type=""logic_boolean"">
        <field name=""BOOL"">TRUE</field>
      </block>
    </value>
  </block>
</xml>";
            var model = new Parser()
                .AddStandardBlocks()
                .Parse(xml);

            Assert.AreEqual(1, model.Blocks.Count);
            Assert.AreEqual(2, model.Blocks.First().Values.Count);

            var output = model.Evaluate();
            
            Assert.AreEqual(true, output);
        }

            [TestMethod]
        public void Test_Logic_Operation_And()
        {
            
            const string xml = @"
<xml xmlns=""http://www.w3.org/1999/xhtml"">
  <block type=""logic_operation"">
    <field name=""OP"">AND</field>
    <value name=""A"">
      <block type=""logic_boolean"">
        <field name=""BOOL"">FALSE</field>
      </block>
    </value>
    <value name=""B"">
      <block type=""logic_boolean"">
        <field name=""BOOL"">TRUE</field>
      </block>
    </value>
  </block>
</xml>";
            var output = new Parser()
                .AddStandardBlocks()
                .Parse(xml)
                .Evaluate();
            
            Assert.AreEqual(false, output);
        }

    }
}