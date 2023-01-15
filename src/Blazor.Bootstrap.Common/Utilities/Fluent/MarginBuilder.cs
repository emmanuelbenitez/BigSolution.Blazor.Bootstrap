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

internal abstract class MarginBuilder<TMarginSide> : SpacingBuilder<Margin, MarginSide, IMarginCombiner, ISupportMargin>, IMarginCombiner, ISupportMargin, IMarginBuilder
    where TMarginSide : MarginSide
{
    protected MarginBuilder(Margin margin, TMarginSide marginSide) : base(margin, marginSide) { }

    #region ISupportMargin Members

    public IAutoMarginBuilder IsAuto()
    {
        return new AutoMarginBuilder(_spacing);
    }

    public IFixedMarginBuilder IsFixedAt(int value)
    {
        return new FixedMarginBuilder(_spacing, value);
    }

    #endregion

    #region Base Class Member Overrides

    protected sealed override IMarginCombiner Combiner => this;

    protected override ISupportMargin Factory => this;

    #endregion
}