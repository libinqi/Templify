#region License

//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

#endregion

namespace Endjin.Templify.Specifications.Domain.Packager.Specifications
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Endjin.Templify.Domain.Domain.Packager.Specifications;
    using Endjin.Templify.Domain.Contracts.Infrastructure;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;

    #endregion

    public abstract class specification_for_file_exclusion_specification : Specification<FileExclusionSpecification>
    {
        protected static List<string> file_list;
        protected static IConfiguration config;

        Establish context = () =>
            {
                subject.FileExclusions = new List<string>
                    {
                        ".nupkg", 
                        ".cache",
                        ".mst",
                        ".msm",
                        ".gitignore",
                        ".idx",
                        ".pack",
                        ".user",
                        ".resharper",
                        ".suo", 
                        ".zz*", 
                        "desktop.ini", 
                        "thumbs.db"
                    };

                subject.DirectoryExclusions = new List<string> { "bin", "obj", "debug", "release", ".git", "_ReSharper.*" };

                file_list = new List<string>
                    {
                        @"C:\__NAME__\.git\hooks\applypatch-msg.sample",
                        @"C:\__NAME__\bin\hooks\applypatch-msg.sample",
                        @"C:\__NAME__\obj\hooks\applypatch-msg.sample",
                        @"C:\__NAME__\debug\hooks\applypatch-msg.sample",
                        @"C:\__NAME__\release\hooks\applypatch-msg.sample",
                        @"C:\__NAME__\hooks\applypatch-msg.cache",
                        @"C:\__NAME__\hooks\applypatch-msg.mst",
                        @"C:\__NAME__\hooks\.gitignore",
                        @"C:\__NAME__\hooks\desktop.cs",
                        @"C:\__NAME__\hooks\templify.nupkg",
                        @"C:\__NAME__\hooks\thumbs.db",
                        @"C:\__NAME__\hooks\desktop.ini",
                        @"C:\__NAME__\hooks\applypatch-msg.idx",
                        @"C:\__NAME__\hooks\applypatch-msg.pack",
                        @"C:\__NAME__\hooks\applypatch-msg.user",
                        @"C:\__NAME__\hooks\applypatch-msg.resharper",
                        @"C:\__NAME__\hooks\applypatch-msg.suo",
                        @"C:\__NAME__\hooks\applypatch-msg.zza",
                        @"C:\__NAME__\_ReSharper.__NAME__\ModuleIds.xml",
                        @"C:\__NAME__\_ReSharper.__NAME__\SymbolCache.bin",
                        @"C:\__NAME__\_ReSharper.__NAME__\BuildScriptCache\.crc",
                        @"C:\__NAME__\_ReSharper.__NAME__\BuildScriptCache\7\6d0481a2.dat",
                    };
            };
    } ;

    [Subject(typeof(FileExclusionSpecification))]
    public class when_the_file_exclusion_specification_is_given_a_list_of_items_to_exclude_with_one_valid_file : specification_for_file_exclusion_specification
    {
        static IEnumerable<string> result;

        Because of = () => result = subject.SatisfyingElementsFrom(file_list.AsQueryable());

        It should_return_one_file = () => result.Count().ShouldEqual(1);
    }
}