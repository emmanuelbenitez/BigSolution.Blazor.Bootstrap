#region Copyright & License

// Copyright © 2020 - 2022 Emmanuel Benitez
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

namespace BigSolution.Bootstrap.Utilities.Fluent;

public interface ISpacingBuilder<out TSpacing, TSpacingSides>
    where TSpacing : Spacing<TSpacingSides>
    where TSpacingSides : SpacingSide
{
    TSpacing Build();
}

public interface ISupportFixedSpacing<out TFixedSpacingBuilder>
{
    TFixedSpacingBuilder IsFixedAt(int value);
}

public interface ISupportAutoSpacing<out TAutoSpacingBuilder>
{
    TAutoSpacingBuilder IsAuto();
}

public interface ISupportMargin : ISupportFixedSpacing<IFixedMarginBuilder>, ISupportAutoSpacing<IAutoMarginBuilder> { }

public interface ISupportPadding : ISupportFixedSpacing<IFixedMarginBuilder>, ISupportAutoSpacing<IAutoMarginBuilder> { }

public interface IFixedMarginBuilder : ISupportSideDefinition<IMarginCombiner> { }

public interface ISpacingCombiner<out TSpacingSideFactory, out TSpacing, TSpacingSides> : ISpacingBuilder<TSpacing, TSpacingSides>
    where TSpacing : Spacing<TSpacingSides>
    where TSpacingSides : SpacingSide
{
    TSpacingSideFactory And { get; }
}
