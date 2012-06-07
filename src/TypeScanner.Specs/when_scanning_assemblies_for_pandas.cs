using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace TypeScanner.Specs
{
    public class when_scanning_assemblies_for_pandas
    {
        static ITypeScanner _messageTypeScanner;
        static List<Type> _result;

        Establish context = () =>
            {
                _messageTypeScanner = new TypeScanner();
            };

        Because of = () => _result = _messageTypeScanner.GetTypesOf<Panda>();

        It should_return_a_list_that_includes_a_chinese_panda = () => _result.ShouldContain(typeof(ChinesePanda));

        It should_return_a_list_that_includes_an_african_panda = () => _result.ShouldContain(typeof(AfricanPanda));

        It should_only_return_those_types = () => _result.Count.ShouldEqual(2);
    }
}