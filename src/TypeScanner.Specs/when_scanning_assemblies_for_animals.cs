using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace TypeScanner.Specs
{
    public class when_scanning_assemblies_for_animals
    {
        static ITypeScanner _messageTypeScanner;
        static List<Type> _result;

        Establish context = () =>
            {
                _messageTypeScanner = new TypeScanner();                                    
            };

        Because of = () => _result = _messageTypeScanner.GetTypesOf<Animal>();

        It should_return_a_list_that_includes_a_grizzly_bear = () => _result.ShouldContain(typeof (GrizzlyBear));

        It should_return_a_list_that_includes_an_antelope = () => _result.ShouldContain(typeof(Antelope));

        It should_return_a_list_that_includes_a_panda = () => _result.ShouldContain(typeof(Panda));

        It should_return_a_list_that_includes_an_african_panda = () => _result.ShouldContain(typeof(Panda));

        It should_return_a_list_that_includes_a_chinese_panda = () => _result.ShouldContain(typeof(Panda));

        It should_return_a_list_that_includes_a_kangaroo = () => _result.ShouldContain(typeof(Kangaroo));

        It should_only_return_those_types = () => _result.Count.ShouldEqual(6);
    }
}