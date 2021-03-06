﻿using CesiumLanguageWriter;
using CesiumLanguageWriter.Advanced;
using NUnit.Framework;

namespace CesiumLanguageWriterTests
{
    public abstract class TestCesiumInterpolatablePropertyWriter<TDerived> : TestCesiumPropertyWriter<TDerived>
        where TDerived : CesiumInterpolatablePropertyWriter<TDerived>
    {
        [Test]
        public void InterpolationAlgorithmValueWritesInterpolationAlgorithmProperty()
        {
            CesiumPropertyWriter<TDerived> property = CreatePropertyWriter("foo");
            property.Open(OutputStream);
            using (TDerived interval = property.OpenInterval())
            {
                interval.WriteInterpolationAlgorithm(CesiumInterpolationAlgorithm.Hermite);
            }
            Assert.AreEqual("{\"foo\":{\"interpolationAlgorithm\":\"HERMITE\"}", StringWriter.ToString());
        }

        [Test]
        public void InterpolationDegreeValueWritesInterpolationDegreeProperty()
        {
            CesiumPropertyWriter<TDerived> property = CreatePropertyWriter("foo");
            property.Open(OutputStream);
            using (TDerived interval = property.OpenInterval())
            {
                interval.WriteInterpolationDegree(3);
            }
            Assert.AreEqual("{\"foo\":{\"interpolationDegree\":3}", StringWriter.ToString());
        }
    }
}
