namespace Endjin.Templify.Domain.Infrastructure
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using CommandLine;

    using Endjin.Templify.Domain.Contracts.Infrastructure;

    #endregion

    [Export(typeof(ICommandLineProcessor))]
    public class CommandLineProcessor : ICommandLineProcessor
    {
        public CommandOptions Process(string[] args)
        {
            var options = new CommandOptions();
            var parser = new CommandLineParser();

            parser.ParseArguments(args, options);

            return options;
        }
    }
}